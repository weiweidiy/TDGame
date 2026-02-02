using System;
using YooAsset;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;
using JFramework.Game;
using System.Threading.Tasks;
using System.Text;
using Adic;

namespace JFramework
{
    public class YooAssetsLoader : IAssetsLoader, IConfigLoader
    {
        public UniTask<GameObject> InstantiateAsync(string location)
        {
            return InstantiateAsync(location, null);
        }

        public async UniTask<GameObject> InstantiateAsync(string location, Transform parent)
        {
            var handle = YooAssets.LoadAssetAsync<GameObject>(location);
            await handle.ToUniTask();
            var h = handle.InstantiateAsync(parent);
            await h;
            return h.Result;
        }

        public async UniTask<T> LoadAssetAsync<T>(string location) where T : UnityEngine.Object
        {
            var handle = YooAssets.LoadAssetAsync<T>(location);
            await handle;
            return handle.AssetObject as T;
        }

        public async Task<byte[]> LoadBytesAsync(string location)
        {
            var text = await LoadAssetAsync<TextAsset>(location);
            return text.bytes;
        }

        public async UniTask<Scene> LoadSceneAsync(string sceneName, SceneMode mode)
        {
            var sMode = mode == SceneMode.Single ? LoadSceneMode.Single : LoadSceneMode.Additive;
            var handle = YooAssets.LoadSceneAsync(sceneName, sMode); 
            await handle.ToUniTask();
            return handle.SceneObject;

        }
    }

}

