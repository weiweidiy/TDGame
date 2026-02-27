using Cysharp.Threading.Tasks;
using Game.Demo;
using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class SceneLoginState : BaseSceneState
    {
        protected override async UniTask OnEnter(object arg)
        {
            var task = base.OnEnter(arg);
            await task;
            var ctrl = context.Facade.GetViewControllerContainer().GetViewController(nameof(UIPanelLoginView)) as UIPanelLoginView;
            ctrl.onLoginClicked += OnLoginClicked;
            ctrl.Open(new ViewData() { prefabName = nameof(UIPanelLogin) });
        }

        public override UniTask OnExit()
        {
            return base.OnExit();
        }
        protected override string GetBGMClipName()
        {
            return "";
        }

        //protected override View[] GetControllers()
        //{
        //    return context.Facade.GetViewControllerContainer().GetViewControllers(GetSceneType().ToString());
        //}


        protected override DemoSceneType GetSceneType()
        {
            return DemoSceneType.SceneLogin;
        }
        protected override string GetUISettingsName()
        {
            return "UISceneLoginSettings";
        }

        #region ¿ØÖÆÆ÷ÊÂ¼þ
        private async void OnLoginClicked()
        {
            //Debug.Log("Login Clicked");
            try
            {
                var url = "https://1.117.228.69:7289/Account/FastLogin";
                var req = new AccountDTO() { Uid = "2222" };

                await context.Facade.GetControllerManager().GetController(nameof(LoginController)).Do(context, url,req);
                //await context.Facade.GetSceneStateMachine().SwitchToState(DemoSceneType.SceneCastle.ToString(), context);
            }
            catch(Exception ex)
            {
                Debug.LogError("Failed to switch to Castle State:" + ex.Message);
                throw;
            }
        }
        #endregion
    }
}
