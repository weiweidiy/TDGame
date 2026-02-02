using Adic;
using Cysharp.Threading.Tasks;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Tiktok
{
    public class TiktokSpritesManager
    {
        [Inject]
        IJConfigManager jConfigManager;

        [Inject]
        IAssetsLoader assetsLoader;

        Dictionary<string , Sprite> spritesCache = new Dictionary<string, Sprite>();

        public async UniTask Initialize()
        {
            var texturesCfgData = jConfigManager.GetAll<TexturesCfgData>();
            //从配置中预加载所有纹理并缓存
            var tasks = new List<UniTask>();
            foreach (var texture in texturesCfgData)
            {
                Debug.Log("---- Load Texture  --------- " + texture.Path);
                var location = texture.Path;
                if (spritesCache.ContainsKey(location))
                    continue;
                var task = LoadSpriteAsync(location, (key, sprite) => {
                
                    if (sprite != null && !spritesCache.ContainsKey(key))
                    {
                        spritesCache.Add(key, sprite);
                    }
                    else
                    {
                        Debug.LogError($"Failed to load texture at {key}");
                    }
                });
                tasks.Add(task);
            }

            await UniTask.WhenAll(tasks);
        }


        private async UniTask LoadSpriteAsync(string location, Action<string, Sprite> onComplete)
        {
            var sprite = await assetsLoader.LoadAssetAsync<Sprite>(location);
            onComplete?.Invoke(location, sprite);
        }

        public Sprite GetSprite(string key)
        {
            if (spritesCache.TryGetValue(key, out var sprite))
            {
                return sprite;
            }
            else
            {
                Debug.LogError($"Sprite not found for key: {key}");
                return null;
            }
        }
    }
}
