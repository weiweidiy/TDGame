using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;


namespace Tiktok
{
    public class UIKachaController : ViewController
    {
        public class ControllerArgs : ControllerBaseArgs
        {
            //to do: add args if needed
        }
        [Inject]
        protected TiktokGameObjectManager gameObjectManager;
        [Inject]
        protected TiktokConfigManager tiktokConfigManager;
        [Inject]
        protected TiktokSpritesManager spritesManager;
        [Inject]
        ILanguageManager languageManager;
        //[Inject]
        //protected UIManager uiManager;
        [Inject]
        UIScrollerUnitViewDataConverter dataConverter;
        [Inject]
        public UIKachaController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<Open>(OnOpenKacha);
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnCloseKacha);
        }


        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<Open>(OnOpenKacha);
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnCloseKacha);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var properties = new UIPanelKachaProperties()
            {

            };
            uiManager.ShowPanel(controllerArgs.panelName, properties);
        }

        //private void OnOpenKacha(Open e)
        //{
        //    var properties = new UIPanelKachaProperties()
        //    {
 
        //    };
        //    uiManager.ShowPanel(nameof(UIPanelKacha), properties);
        //}

        private void OnCloseKacha(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelKacha.UIPanelKachaPanelData;
            if(panelData == null)
            {
                return;
            }
            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
        }
    }
}
