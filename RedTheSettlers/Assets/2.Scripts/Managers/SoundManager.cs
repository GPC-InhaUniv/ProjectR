﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    /// <summary>
    /// 사운드매니저
    /// 담당자 : 정진영
    /// ++++++사용법++++++
    /// 1. BGM변경 SoundManager.Instance.ChangeBGM("bgm_board_field",true); //클립이름,부드럽게 전환할것인가
    /// 2. SFX재생 SoundManager.Instance.PlaySFX("CampFire",false); //클립이름, 루프들 돌릴것인가
    /// 3. SFX정지 SoundManager.Instance.StopSFXByName("CampFire"); //클립이름
    /// </summary>
    [SerializeField]
    public class SoundManager : Singleton<SoundManager>
    {
        protected SoundManager() { }
        //[SerializeField]
        //public int BGMsClipSize;
        //public int SFXsClipSize;

        //[SerializeField]
        [Header("BGM clips-최대 8개(동작시 초기화/수정시 상의)"), Tooltip("오디오 클립들")]
        public AudioClip[] BGMs = new AudioClip[8];
        
        [Header("SFX clips-최대 20개(동작시 초기화/수정시 상의)"), Tooltip("오디오 클립들")]
        public AudioClip[] SFXs = new AudioClip[20];

        [Header("SFX clip을 재생시킬 AudioSource수_(기본 3개_늘려도됨)"), Tooltip("오디오 소스들-효과음이 계속 씹히면 수를 늘려주면 됨")]
        public int audioSouseCount=3;


        [Header("BGM 볼륨")]
        public float BGMvolume;

        [Header("SFX 볼륨")]
        public float SFXvolume;

        private AudioSource BGMsource;
        private AudioSource[] SFXsource;

        //public delegate void CallBack();
        //CallBack BGMendCallBack;


        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            //클립수 초기화
            if (8 < BGMs.Length)
            {
                AudioClip[] newBGMs = new AudioClip[8];
                for (int i = 0; i < newBGMs.Length; i++)
                {
                    newBGMs[i] = BGMs[i];
                }
                BGMs = newBGMs;
            }
            if (20 < SFXs.Length)
            {
                AudioClip[] newSFXs = new AudioClip[20];
                for (int i = 0; i < newSFXs.Length; i++)
                {
                    newSFXs[i] = SFXs[i];
                }
                SFXs = newSFXs;
            }

            BGMsource = gameObject.AddComponent<AudioSource>();
            BGMsource.volume = BGMvolume;
            BGMsource.playOnAwake = false;
            BGMsource.loop = true;


            //SFX 소스 초기화
            SFXsource = new AudioSource[audioSouseCount];
            
            for (int i = 0; i < SFXsource.Length; i++)
            {
                SFXsource[i] = gameObject.AddComponent<AudioSource>();
                SFXsource[i].playOnAwake = false;
                SFXsource[i].volume = SFXvolume;
            }

            //ChangeBGM("bgm_game_field", true);
        }

        private void Update()
        {
            //bgm 부분
            if (!isChanging) return;
            
            //재생중인 오디오의 볼륨을 낮춤
            if(isEnd == false)
            {
                BGMsource.volume -= (Time.time - startTime) * ChangingSpeed;
                if (BGMsource.volume <= 0) isEnd = true;
            }
            if(isEnd == true)
            {
                float progress = (Time.time - startTime) * ChangingSpeed;//부드러운 오디오 전환
                if (progress > 1)
                {
                    isChanging = false;
                    BGMsource.volume = progress;
                    BGMsource.clip = changeClip;
                    BGMsource.Play();
                }
            }
        }



        /// <summary>
        /// BGM 부분
        /// </summary>
        private AudioClip changeClip;//바뀌는 클립
        private bool isChanging = false;
        private bool isEnd = true;
        private float startTime;


        [SerializeField]
        [Header("Changing speed-배경음 바꾸는 속도")]
        public float ChangingSpeed;

        public void ChangeBGM(string name, bool isSmooth)//브금 변경 (브금이름 , 부드럽게 바꾸기), CallBack callback = null
        {
            //BGMendCallBack = callback;

            changeClip = null;
            for (int i = 0; i < BGMs.Length; i++)//배경음 클립 탐색
            {
                if (BGMs[i].name == name)
                {
                    changeClip = BGMs[i];
                }
            }

            if (changeClip == null)//없으면 이탈
                return;

            if (!isSmooth)
            {
                BGMsource.clip = changeClip;
                BGMsource.Play();
            }
            else
            {
                startTime = Time.time;
                isEnd = false;
                isChanging = true;
            }
        }
        
        /// <summary>
        /// SFX 부분
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        public void PlaySFX(string name, bool loop)//효과음 재생 (필요한것_클립이름,루프할것인지,볼륨크기)
        {
            for (int i = 0; i < SFXs.Length; i++)
            {
                if (SFXs[i].name == name)
                {
                    AudioSource a = GetEmptySource();
                    a.loop = loop;
                    a.pitch = SFXvolume;
                    a.clip = SFXs[i];
                    a.Play();
                    return;
                }
            }
        }

        /// <summary>
        /// 멈추고 싶은 효과음 정지
        /// </summary>
        /// <param name="name"></param>
        public void StopSFXByName(string name)
        {
            for(int i = 0; i<SFXsource.LongLength; i++)
            {
                if (SFXsource[i].clip.name == name)
                {
                    SFXsource[i].Stop();
                    return;
                }
            }
        }

        private AudioSource GetEmptySource()//비어있는 오디오 소스 반환
        {
            int lageindex = 0;
            float lageProgress = 0;
            for (int i = 0; i < SFXsource.Length; i++)
            {
                if (!SFXsource[i].isPlaying)
                {
                    return SFXsource[i];
                }

                //만약 비어있는 오디오 소스를 못찿으면 가장 진행도가 높은 오디오 소스 반환(루프중인건 스킵)
                float progress = SFXsource[i].time / SFXsource[i].clip.length;
                if (progress > lageProgress && !SFXsource[i].loop)
                {
                    lageindex = i;
                    lageProgress = progress;
                }
            }
            return SFXsource[lageindex];
        }
    }
}

