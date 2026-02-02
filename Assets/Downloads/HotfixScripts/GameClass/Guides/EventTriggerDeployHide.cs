using Adic;
using Game.Common;
using JFramework;


namespace Tiktok
{
    public class EventTriggerDeployHide : BaseEventTrigger
    {
        [Inject]
        UIManager uiManager;
        public override void AddListeners()
        {
            eventManager.AddListener<UIDeployController.EventPanelClosed>(OnDeployClose);
        }
        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UIDeployController.EventPanelClosed>(OnDeployClose);
        }
        private void OnDeployClose(UIDeployController.EventPanelClosed e)
        {
            Trigger(e.Body);
        }
    }
}

