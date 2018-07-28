using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public enum AssetBundleNumbers
{
    Player,
    Enemy,
    Boss,
    Tile,
    UI, // ???
    cube, // 테스트용으로 사용 // 추후에 제거할 것
    sphere // 테스트용으로 사용 // 추후에 제거할 것
}

namespace RedTheSettlers
{
    /// <summary>
    /// 작성자 : 박지용
    /// 게임에서 사용할 에셋번들을 관리하는 매니저
    /// </summary>
    namespace Manager
    {
        public class AssetBundleManager : MonoBehaviour
        {
            private const string assetBundleDirectory = "Assets/AssetBundles";
            private Dictionary<int, string> WebPaths = new Dictionary<int, string>();

            /// <summary>
            /// 현재 에셋번들이 최신버전인지 체크한다. 
            /// 추후 구현 예정
            /// </summary>
            public bool CheckAssetBundleVersion()
            {
                return false;
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

            private string GetAssetBundleName(AssetBundleNumbers number)
            {
                return number.ToString();
            }

            private IEnumerator SaveAssetBundleOnDisk(AssetBundleNumbers number)
            {
                string assetBundleName = GetAssetBundleName(number);
                string uri = GetAssetBundlePath(number) + "/" + assetBundleName;

                UnityWebRequest request = UnityWebRequest.Get(uri);
                yield return request.Send();

                if (!Directory.Exists(assetBundleDirectory))
                {
                    Directory.CreateDirectory(assetBundleDirectory);
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "AssetBundle Directory 생성");
                }

                FileStream fs = new FileStream(assetBundleDirectory + "/" + assetBundleName, System.IO.FileMode.Create); // Create는 있으면 덮어씀, CreateNew는 새로 생성;
                fs.Write(request.downloadHandler.data, 0, (int)request.downloadedBytes);
                fs.Close();

                LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "다운로드 완료" + " " + request.downloadedBytes + "Bytes");
            }

            private IEnumerator LoadAssetBundleFromLocalDist(AssetBundleNumbers number)
            {
                string assetBundleName = GetAssetBundleName(number);
                var loadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", assetBundleName));

                if (loadedAssetBundle == null)
                {
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "에셋 번들 로드 실패");
                    yield break;
                }
                else
                    LogManager.Instance.UserDebug(LogColor.Orange, "AssetBundleManager", "에셋 번들 로드 성공");

                var prefab = loadedAssetBundle.LoadAsset<GameObject>(assetBundleName);
                Instantiate(prefab, Vector3.zero, Quaternion.identity); // 오브젝트 풀에 저장하게 수정할 것
            }
        }
    }
}