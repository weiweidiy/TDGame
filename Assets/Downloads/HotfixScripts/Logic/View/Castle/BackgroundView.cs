using JFramework.Unity;
using System;
using UnityEngine;

namespace Game
{
    public class BackgroundViewData : ViewData
    {
        public Transform parent; //父物体
    }
    public class BackgroundView : View
    {
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Open<TArg>(TArg args)
        {
            var prefabName = (args as BackgroundViewData)?.prefabName;
            var parent = (args as BackgroundViewData)?.parent;
            var goManager = GetGameObjectManager();
            goManager.Rent(prefabName, parent);
        }

        public override void Refresh<TArg>(TArg args)
        {
            throw new NotImplementedException();
        }
    }

}