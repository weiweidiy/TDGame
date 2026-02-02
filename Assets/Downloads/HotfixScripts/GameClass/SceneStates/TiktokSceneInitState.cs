using Adic;
using Cysharp.Threading.Tasks;
using Game.Common;
using JFramework;

namespace Tiktok
{
    public class TiktokSceneInitState : BaseSceneState
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
            throw new System.NotImplementedException();
        }

        protected override ViewController[] GetControllers()
        {
            throw new System.NotImplementedException();
        }

        protected override SceneType GetSceneType()
        {
            throw new System.NotImplementedException();
        }

        //protected override IAssetsLoader AssetsLoader => throw new System.NotImplementedException();
        protected override string GetUISettingsName()
        {
            throw new System.NotImplementedException();
        }


    }
}
