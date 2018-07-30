using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace RedTheSettlers
{
    public enum AssetBundleNumbers
    {
        Player,
        Enemy,
        Boss,
        Tile, // unload(false)
        UI, // ???
        cube, // 테스트용으로 사용 // 추후에 제거할 것
        sphere, // 테스트용으로 사용 // 추후에 제거할 것
        objects, // 테스트용으로 사용 // 추후에 제거할 것
    }

    /// <summary>
    /// 작성자 : 박지용
    /// 게임에서 사용할 에셋번들을 관리하는 매니저
    /// </summary>
    namespace UnitTest
    {
        public class AssetBundleManagerTest : Singleton<AssetBundleManagerTest>
        {
            private const string assetBundleDirectory = "Assets/0.AssetBundles/";
            private Dictionary<int, string> WebPaths = new Dictionary<int, string>();

            private void Start()
            {
                SetWebpaths();
            }

            private void SetWebpaths()
            {
                WebPaths.Add((int)AssetBundleNumbers.Player, "");
                WebPaths.Add((int)AssetBundleNumbers.Enemy, "");
                WebPaths.Add((int)AssetBundleNumbers.Boss, "");
                WebPaths.Add((int)AssetBundleNumbers.Tile, "");
                WebPaths.Add((int)AssetBundleNumbers.UI, "");
                WebPaths.Add((int)AssetBundleNumbers.cube, "https://drive.google.com/uc?authuser=0&id=1PqZJysMx1M6QCVwIquRFK-gm37Qtvaes&export=download");
                WebPaths.Add((int)AssetBundleNumbers.sphere, "https://drive.google.com/uc?authuser=0&id=1lzdECFhmaOgVUjwglP8NgTgF9cx0P0lJ&export=download");
            }

            /// <summary>
            /// 현재 에셋번들이 최신버전인지 체크한다. 
            /// - 추후 구현 예정 -
            /// </summary>
            public bool CheckAssetBundleVersion()
            {
                //DataManager.Version
                return false;
            }

            /// <summary>
            /// 정해진 웹주소에서 에셋번들을 다운 받는다. 
            /// 실사용시에는 매개변수에 AssetBundleNumbers를 받아 구분한다.
            /// </summary>
            public void DownLoadAssetBundle()
            {
                
            }

            public void DownCube()
            {
                StartCoroutine(SaveAssetBundleOnDisk(AssetBundleNumbers.cube));
            }

            public void DownSphere()
            {
                StartCoroutine(SaveAssetBundleOnDisk(AssetBundleNumbers.sphere));
            }

            /// <summary>
            /// 로컬 드라이브에서 에셋번들을 불러온다.
            /// 실사용시에는 매개변수에 AssetBundleNumbers를 받아 구분한다.
            /// </summary>
            public void LocalLoadAssetBundle()
            {

            }

            public void LoadCube()
            {
                StartCoroutine(LoadAssetBundleFromLocalDisk(AssetBundleNumbers.cube));
            }

            public void LoadSphere()
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

                Debug.Log(uri);

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

                Debug.Log(uri);

                UnityWebRequest request = UnityWebRequest.GetAssetBundle(uri, 0);
                yield return request.Send();

                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

                GameObject prefab;

                prefab = bundle.LoadAsset<GameObject>("cube"); Instantiate(prefab);
                prefab = bundle.LoadAsset<GameObject>("sphere"); Instantiate(prefab);
                Instantiate(prefab);
                Instantiate(prefab);
                Instantiate(prefab);
                Instantiate(prefab);
                Instantiate(prefab);

                yield return Resources.UnloadUnusedAssets(); // 호출되지 않은 번들 제거
                bundle.Unload(true);
            }
        }
    }
}