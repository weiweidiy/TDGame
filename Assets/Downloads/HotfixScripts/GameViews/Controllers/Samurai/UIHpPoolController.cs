using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;


namespace Tiktok
{
    public class UIHpPoolController : ViewController
    {
        public class ControllerArgs : ControllerBaseArgs
        {

        }
        [Inject]
        protected TiktokGameObjectManager gameObjectManager;
        [Inject]
        protected TiktokConfigManager tiktokConfigManager;
        [Inject]
        protected TiktokSpritesManager spritesManager;
        [Inject]
        TiktokGameDataManager tiktokGameDataManager;
        [Inject]
        ILanguageManager languageManager;
        [Inject]
        public UIHpPoolController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();

            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnCloseHpPool);
        }



        public override void OnStop()
        {
            base.OnStop();

            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnCloseHpPool);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;
            
            var properties = new UIPanelHpPoolProperties()
            {
                // Initialize properties here if needed
            };
            var screenId = uiManager.ShowPanel(controllerArgs.panelName, properties);
        }

        private void OnCloseHpPool(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelHpPool.UIPanelHpPoolPanelData;
            if (panelData == null) return;

            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
        }
    }
}
