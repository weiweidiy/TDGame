using Cysharp.Threading.Tasks;
using JFramework;
using JFramework.Unity;
using System.Threading.Tasks;

namespace Game.Demo
{
    public class SceneCastleState : BaseSceneState
    {
        protected override async UniTask OnEnter(object arg)
        {
            await base.OnEnter(arg);

            await OpenBackground();
            await OpenStartBattleMenu();
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

        /// <summary>
        /// 打开背景界面
        /// </summary>
        /// <returns></returns>
        async UniTask OpenBackground()
        {
            var ctrl = GetController<BackgroundView>() as BackgroundView;
            var assetsQuery = context.Facade.GetGameAssetsQuary() as GameAssetsQuary;
            var spBackground = await assetsQuery.GetBackgroundSpriteAsync();

            ctrl.Open(new BackgroundViewData()
            {
                prefabName = "Castle"
                ,
                parent = goRoot
                ,
                sp = spBackground
            });
        }

        /// <summary>
        /// 打开开始战斗菜单界面
        /// </summary>
        /// <returns></returns>
        async UniTask OpenStartBattleMenu()
        {
            var ctrl = GetController<UIPanelStartMenuView>();
            ctrl.Open(new ViewData() { prefabName = nameof(UIPanelStartMenu) });
            await UniTask.CompletedTask;
        }
    }
}
