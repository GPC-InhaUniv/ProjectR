﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;

namespace RedTheSettlers
{
    public enum AssetBundleNumbers
    {
        Player,
        Skill,
        Enemy,
        Boss1,
        Boss2,
        Boss3,
        Tile, // unload(false)
        UI, // ???
        objects, // 테스트용으로 사용 // 추후에 제거할 것
        canvas, // 테스트용으로 사용 // 추후에 제거할 것
    }

    /// <summary>
    /// 작성자 : 박지용
    /// 게임에서 사용할 에셋번들을 관리하는 매니저
    /// </summary>
    namespace UnitTest
    {
        public class AssetBundleManagerTest : Singleton<AssetBundleManagerTest>
        {
            private Hash128 hash; // DataManager에서 버전 정보를 가져옴. 웹에서 새로 받은 Manifest의 hash와 비교하여 버전 체크. 다르면 해당 번들을 다운.
            private const string assetBundleDirectory = "Assets/0.AssetBundles/";
            private Dictionary<int, string> WebPaths = new Dictionary<int, string>();
            private Dictionary<int, AssetBundle> Bundles = new Dictionary<int, AssetBundle>();

            private void Start()
            {
                SetWebpaths();
            }

            private void SetWebpaths()
            {
                WebPaths.Add((int)AssetBundleNumbers.Player, "");
                WebPaths.Add((int)AssetBundleNumbers.Skill, "");
                WebPaths.Add((int)AssetBundleNumbers.Enemy, "");
                WebPaths.Add((int)AssetBundleNumbers.Boss1, "");
                WebPaths.Add((int)AssetBundleNumbers.Boss2, "");
                WebPaths.Add((int)AssetBundleNumbers.Boss3, "");
                WebPaths.Add((int)AssetBundleNumbers.Tile, "");
                WebPaths.Add((int)AssetBundleNumbers.UI, "");
                WebPaths.Add((int)AssetBundleNumbers.canvas, "https://drive.google.com/uc?authuser=0&id=1AHBIgStWfP28ODXGaY3pxU2OslSTsl3Q&export=download");
                WebPaths.Add((int)AssetBundleNumbers.objects, "https://drive.google.com/uc?authuser=0&id=189GqP1ULCgaZDLq-x9VCrH3eCDOv9qpJ&export=download");
            }

            private void AddBundles(AssetBundleNumbers num ,AssetBundle bundle)
            {
                if(!Bundles.ContainsKey((int)num))
                {
                    Bundles.Add((int)num, bundle);
                }
            }









            /// <summary>
            /// 정해진 웹주소에서 에셋번들을 다운 받는다. 
            /// 실사용시에는 매개변수에 AssetBundleNumbers를 받아 구분한다.
            /// </summary>
            public void DownLoadAssetBundle()
            {
                
            }

            public void DownCanvas()
            {
                StartCoroutine(SaveAssetBundleOnDisk(AssetBundleNumbers.canvas));
            }

            public void DownObjects()
            {
                StartCoroutine(SaveAssetBundleOnDisk(AssetBundleNumbers.objects));
            }

            /// <summary>
            /// 로컬 드라이브에서 에셋번들을 불러온다.
            /// 실사용시에는 매개변수에 AssetBundleNumbers를 받아 구분한다.
            /// </summary>
            public void LocalLoadAssetBundle()
            {

            }

            public void LoadCanvas()
            {
                StartCoroutine(LoadAssetBundleFromLocalDisk(AssetBundleNumbers.canvas));
            }

            public void LoadObjects()
            {
                StartCoroutine(LoadAssetBundleFromLocalDisk(AssetBundleNumbers.objects));
            }

            private string GetAssetBundlePath(AssetBundleNumbers key)
            {
                string bundleName = string.Empty;
                if (!WebPaths.TryGetValue((int)key, out bundleName))
                {
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "Dictionary에 존재하지 않는 번들입니다.");
                    return null;
                }
                return bundleName;
            }

            private string GetAssetBundleName(AssetBundleNumbers number)
            {
                return number.ToString();
            }

            private IEnumerator SaveAssetBundleOnDisk(AssetBundleNumbers number)
            {
                string assetBundleName = GetAssetBundleName(number);
                string uri = GetAssetBundlePath(number);

                UnityWebRequest request = UnityWebRequest.Get(uri);
                yield return request.Send();

                if (!Directory.Exists(assetBundleDirectory))
                {
                    Directory.CreateDirectory(assetBundleDirectory);
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "AssetBundle Directory 생성");
                }
                else
                {
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "해당 폴더가 이미 존재합니다.");
                }

                FileStream fs = new FileStream(assetBundleDirectory + assetBundleName, System.IO.FileMode.Create); // Create는 있으면 덮어씀, CreateNew는 새로 생성;
                fs.Write(request.downloadHandler.data, 0, (int)request.downloadedBytes);
                fs.Close();

                LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "다운로드 완료" + " " + request.downloadedBytes + "Bytes");
            }

            private IEnumerator LoadAssetBundleFromLocalDisk(AssetBundleNumbers number)
            {
                string assetBundleName = GetAssetBundleName(number);
                string uri = "file:///" + Application.dataPath + "/0.AssetBundles/" + assetBundleName;

                UnityWebRequest request = UnityWebRequest.GetAssetBundle(uri);
                yield return request.Send();

                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                AddBundles(number, bundle);

                //AssetBundleManifest manifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                //Hash128 newHash = manifest.GetAssetBundleHash(assetBundleName);
            }

            /// <summary>
            /// 현재 에셋번들이 최신버전인지 체크한다. 
            /// - 추후 구현 예정 -
            /// </summary>
            public IEnumerator CheckAssetBundleVersion(AssetBundleNumbers number)
            {
                string assetBundleName = GetAssetBundleName(number) + ".manifest";
                string uri = GetAssetBundlePath(number);

                UnityWebRequest request = UnityWebRequest.Get(uri);
                yield return request.Send();

                if (!Directory.Exists(assetBundleDirectory))
                {
                    Directory.CreateDirectory(assetBundleDirectory);
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "AssetBundle Directory 생성");
                }
                else
                {
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "해당 폴더가 이미 존재합니다.");
                }

                FileStream fs = new FileStream(assetBundleDirectory + assetBundleName, System.IO.FileMode.Create); // Create는 있으면 덮어씀, CreateNew는 새로 생성;
                fs.Write(request.downloadHandler.data, 0, (int)request.downloadedBytes);
                fs.Close();

                LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "다운로드 완료" + " " + request.downloadedBytes + "Bytes");

                fs = new FileStream(assetBundleDirectory + assetBundleName, System.IO.FileMode.Open);
                fs.Read()
                
                //string newManifest = null;
                //byte[] bytes = request.downloadHandler.data;
                //newManifest += Encoding.Default.GetString(bytes);

                //string[] splitText = new string[2];
                //splitText[0] = "Hash: ";
                //splitText[1] = "  TypeTreeHash:";

                //newManifest = newManifest.Substring(newManifest.IndexOf(splitText[0], newManifest.IndexOf(splitText[1])));

                //Hash128 newhash = Hash128.Parse(newManifest);
                //Debug.Log(newhash);
                ////Hash128 newHash;
                //AssetBundleManifest manifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                //Hash128 newHash = manifest.GetAssetBundleHash(assetBundleName);

                //Debug.Log(newHash);

                //AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                //AddBundles(number, bundle);

                //AssetBundleManifest manifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                //Hash128 newHash = manifest.GetAssetBundleHash(assetBundleName);

                ////DataManager.hash[player].equalr(newhash);
                //if(DataManager.hash[0].Equals(newHash))
                //{
                //    return true;
                //}
                //return false;
            }

            public void CloneObjects()
            {
                AssetBundle bundle;
                Bundles.TryGetValue((int)AssetBundleNumbers.objects, out bundle);

                GameObject prefab;
                prefab = bundle.LoadAsset<GameObject>("cube"); Instantiate(prefab);
                prefab = bundle.LoadAsset<GameObject>("sphere"); Instantiate(prefab);

                Resources.UnloadUnusedAssets(); // 호출되지 않은 번들 제거
                //bundle.Unload(true);
            }

            public void CloneCanvas()
            {
                AssetBundle bundle;
                Bundles.TryGetValue((int)AssetBundleNumbers.canvas, out bundle);

                GameObject canvas;
                canvas = bundle.LoadAsset<GameObject>("canvas");
                Instantiate(canvas);
            }
        }
    }
}