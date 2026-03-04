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
            await base.OnEnter(arg);

            OpenLoginPanel();
        }



        public override UniTask OnExit()
        {
            CloseLoginPanel();
            return base.OnExit();
        }
        protected override string GetBGMClipName()
        {
            return "";
        }


        protected override DemoSceneType GetSceneType()
        {
            return DemoSceneType.SceneLogin;
        }
        protected override string GetUISettingsName()
        {
            return "UISceneLoginSettings";
        }

        void OpenLoginPanel()
        {
            var ctrl = GetController<UIPanelLoginView>();
            ctrl.onLoginClicked += OnLoginClicked;
            ctrl.Open(new ViewData() { prefabName = nameof(UIPanelLogin) });
        }

        void CloseLoginPanel()
        {
            var ctrl = GetController<UIPanelLoginView>();
            ctrl.onLoginClicked -= OnLoginClicked;
            ctrl.Close();
        }

        #region ¿ØÖÆÆ÷ÊÂ¼þ
        private async void OnLoginClicked()
        {
            //Debug.Log("Login Clicked");
            try
            {
                var url = GameLauncher.ServerUrl+ "Account/FastLogin";
                var req = new AccountDTO() { Uid = "2222" };
                var urlEnter = GameLauncher.ServerUrl + "api/Game/EnterGame";
                var reqEnter = new ReqEnterGame() {  };
                var socketUrl = GameLauncher.ServerUrl;

                await context.Facade.GetControllerManager().GetController(nameof(LoginController)).Do(context, url,req,urlEnter,reqEnter, socketUrl);
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
