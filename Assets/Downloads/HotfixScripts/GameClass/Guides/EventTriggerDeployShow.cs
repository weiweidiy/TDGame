using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using UnityEngine;


namespace Tiktok
{
    public class EventTriggerDeployShow : BaseEventTrigger
    {
        [Inject]
        UIManager uiManager;

        public int guideIndex;
        public override void AddListeners()
        {
            eventManager.AddListener<UIDeployController.EventPanelShowed>(OnDeployOpen);
        }
        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UIDeployController.EventPanelShowed>(OnDeployOpen);
        }
        private void OnDeployOpen(UIDeployController.EventPanelShowed e)
        {
            var panel = e.Body as UIPanelDeploy;

            GameObject go = null;

            go = panel.GetGuideTarget(guideIndex);

            Trigger(go.GetComponent<RectTransform>());
        }
    }
}

