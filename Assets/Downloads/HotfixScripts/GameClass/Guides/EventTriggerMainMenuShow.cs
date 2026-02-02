using Adic;
using Game.Common;
using JFramework.Game.View;
using System.Collections.Generic;
using UnityEngine;
using static JFramework.Game.View.UIPanelMainMenu;


namespace Tiktok
{
    public class EventTriggerMainMenuShow : BaseEventTrigger
    {
        public UIMainEntrance entrance;
        public override void AddListeners()
        {
            eventManager.AddListener<UIMainMenuController.EventPanelShowed>(OnMainMenuShow);
        }
        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UIMainMenuController.EventPanelShowed>(OnMainMenuShow);
        }
        private void OnMainMenuShow(UIMainMenuController.EventPanelShowed e)
        {
            var go = e.Body as List<GameObject>;
            var rt = go[0].GetComponent<RectTransform>();

            Trigger(rt);
        }
    }
}

