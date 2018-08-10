using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace RedTheSettlers.GameSystem
{
    public class AssetBundleManager : Singleton<AssetBundleManager>
    {
        private string assetBundleDirectory = AssetBundleSettings.assetBundleDirectory;
        private int HashCodeLine = AssetBundleSettings.HashCodeLine;

        public Dictionary<int, string> WebPaths = new Dictionary<int, string>();
        public Dictionary<int, string> WebManifest = new Dictionary<int, string>();
        private Dictionary<int, AssetBundle> Bundles = new Dictionary<int, AssetBundle>();

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void AddBundles(AssetBundleNumbers num, AssetBundle bundle)
        {
            if (!Bundles.ContainsKey((int)num))
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

        /// <summary>
        /// 로컬 드라이브에서 에셋번들을 불러온다.
        /// 실사용시에는 매개변수에 AssetBundleNumbers를 받아 구분한다.
        /// </summary>
        public void LocalLoadAssetBundle()
        {

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

        private string GetManifestPath(AssetBundleNumbers key)
        {
            string bundleName = string.Empty;
            if (!WebManifest.TryGetValue((int)key, out bundleName))
            {
                LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "Dictionary에 존재하지 않는 메니페스트 파일입니다.");
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

            FileStream fs = new FileStream(assetBundleDirectory + assetBundleName, FileMode.Create); // Create는 있으면 덮어씀, CreateNew는 새로 생성;
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
        }

        /// <summary>
        /// 현재 에셋번들이 최신버전인지 체크한다. 
        /// </summary>
        public IEnumerator CheckAssetBundleVersion(AssetBundleNumbers number)
        {
            string assetBundleName = GetAssetBundleName(number) + ".manifest";
            string uri = GetManifestPath(number);

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

            FileStream fs = new FileStream(assetBundleDirectory + assetBundleName, FileMode.Create); // Create는 있으면 덮어씀, CreateNew는 새로 생성;
            fs.Write(request.downloadHandler.data, 0, (int)request.downloadedBytes);
            fs.Close();

            LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "다운로드 완료" + " " + request.downloadedBytes + "Bytes");

            /////////////////////////////////////////////////////////////

            string newManifest = string.Empty;
            //string nowManifest = string.Empty; // DataManager에서 받아옴
            string tempHash = "e8e649b24e98b76009451b3b64b5e42e";


            fs = new FileStream(assetBundleDirectory + assetBundleName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);


            for (int i = 0; i < HashCodeLine; i++)
            {
                newManifest = sr.ReadLine();
                Debug.Log(i + ": " + newManifest);
            }
            sr.Close(); fs.Close();

            string[] split = newManifest.Split(' ');
            newManifest = split[split.Length - 1];
            Debug.Log(newManifest);

            if (newManifest.CompareTo(tempHash) == 0) Debug.Log("같은 파일");
            else Debug.Log("다른 파일. 에셋번들 다운로드");
        }
    }
}