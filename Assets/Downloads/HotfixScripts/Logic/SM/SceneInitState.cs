using Cysharp.Threading.Tasks;
using JFramework.Unity;
using System;

namespace Game.Demo
{
    public class SceneInitState : BaseSceneState
    {


        protected override UniTask OnEnter(object arg)
        {
            return UniTask.CompletedTask;
        }
        public override UniTask OnExit()
        {
            return UniTask.CompletedTask;
        }

        protected override string GetBGMClipName()
        {
            return "";
        }

        //protected override View[] GetControllers()
        //{
        //    return null;
        //}

        protected override DemoSceneType GetSceneType()
        {
            return DemoSceneType.Init;
        }

        protected override string GetUISettingsName()
        {
            return "";
        }

    }
}
