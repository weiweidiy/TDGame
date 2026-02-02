using Adic;
using Adic.Container;
using Cysharp.Threading.Tasks;
using Game.Common;
using GameCommands;
using JFramework;
using JFramework.Extern;
using JFramework.Game;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tiktok
{
    public class TiktokSceneLoginState : BaseSceneState
    {
        [Inject("Login")]
        ViewController[] controllers;

        [Inject]
        TiktokSpritesManager tiktokSpritesManager;

        protected override async UniTask OnEnter(object arg)
        {
            await base.OnEnter(arg);

            await tiktokSpritesManager.Initialize(); //从startupgame移过来，确保登录场景也初始化贴图管理器

            var controllerArgs = new UILoginController.ControllerArgs
            {
                panelName = nameof(UIPanelLogin),
            };
            eventManager.Raise<UILoginController.Open>(controllerArgs);
        }


        public override void AddListeners()
        {
            base.AddListeners();
            eventManager.AddListener<UILoginController.EventEnterGame>(RequestEnterGame);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            eventManager.RemoveListener<UILoginController.EventEnterGame>(RequestEnterGame);
        }

        private void RequestEnterGame(UILoginController.EventEnterGame e)
        {
            var dispatcher = container.GetCommandDispatcher();
            dispatcher.Dispatch<CommandLogin>(context);
        }

        protected override string GetUISettingsName()
        {
            return "UISceneLoginSettings";
        }

        protected override ViewController[] GetControllers()
        {
            return controllers;
        }

        protected override SceneType GetSceneType()
        {
            return SceneType.SceneLogin;
        }

        protected override string GetBGMClipName()
        {
            return tiktokConfigManager.GetLoginMusic();
        }


    }
}
