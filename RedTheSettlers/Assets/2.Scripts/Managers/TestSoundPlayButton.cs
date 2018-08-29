using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class TestSoundPlayButton : MonoBehaviour
    {
        public void OnClickChangeBgm()
        {
            //Debug.Log();
            SoundManager.Instance.ChangeBGM("bgm_board_field",true);
        }

        public void OnClickPlaySound1()
        {
            SoundManager.Instance.PlaySFX("CampFire");
        }

        public void OnClickPlaySound2()
        {
            SoundManager.Instance.PlaySFX("FireExplosion2");
        }

        public void OnClickStopSound()
        {
            SoundManager.Instance.StopSFXByName("CampFire");
        }

    }
}
