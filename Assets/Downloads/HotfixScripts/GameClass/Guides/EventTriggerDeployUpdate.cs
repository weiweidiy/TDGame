using Adic;
using Game.Common;
using JFramework;
using UnityEngine;


namespace Tiktok
{
    public class EventTriggerDeployUpdate : BaseEventTrigger
    {
        [Inject]
        UIManager uiManager;

        [Inject]
        UIDeployController uiDeployController;
        public override void AddListeners()
        {
            eventManager.AddListener<FormationDeployModel.EventUpdate>(OnDeployUpdate);
        }
        public override void RemoveListeners()
        {
            eventManager.RemoveListener<FormationDeployModel.EventUpdate>(OnDeployUpdate);
        }
        private void OnDeployUpdate(FormationDeployModel.EventUpdate e)
        {
            var rt = uiDeployController.GetPanel().GetCloseGameObject().GetComponent<RectTransform>();
            Trigger(rt);
        }
    }

}

