using Cysharp.Threading.Tasks;
using JFramework.Unity;
using System.Threading.Tasks;

namespace Game.Demo
{
    public class SceneCastleState : BaseSceneState
    {
        protected override async UniTask OnEnter(object arg)
        {
            await base.OnEnter(arg);
            var ctrl = context.Facade.GetViewControllerContainer().GetViewController(nameof(BackgroundView)) as BackgroundView;
            
            ctrl.Open(new BackgroundViewData() { prefabName = "Castle" , parent = goRoot });
        }
        public override UniTask OnExit()
        {
            return base.OnExit();
        }

        protected override string GetBGMClipName()
        {
            return "";
        }

        protected override DemoSceneType GetSceneType()
        {
            return DemoSceneType.SceneCastle;
        }

        protected override string GetUISettingsName()
        {
            return "UISceneCastleSettings";
        }


    }
}
