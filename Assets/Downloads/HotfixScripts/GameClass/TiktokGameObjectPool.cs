using Adic;
using Cysharp.Threading.Tasks;
using Game.Common;
using JFramework;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Tiktok
{
    public class TiktokGameObjectPool : BaseGameObjectPool
    {
        [Inject]
        protected IAssetsLoader _assetsLoader;

        protected override IAssetsLoader GetAssetLoader()
        {
            return _assetsLoader;
        }

    }
}
