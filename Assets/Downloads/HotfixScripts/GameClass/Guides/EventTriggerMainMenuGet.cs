using Adic;
using Game.Common;
using UnityEngine;
using static JFramework.Game.View.UIPanelMainMenu;


namespace Tiktok
{
    public class EventTriggerMainMenuGet : BaseEventTrigger
    {
        [Inject]
        UIMainMenuController controller;

        public UIMainEntrance entrance;
        public override void AddListeners()
        {
            var rt = controller.GetPanel().GetMenuGameObject(entrance).GetComponent<RectTransform>();
            Trigger(rt);
        }
        public override void RemoveListeners()
        {

        }

    }
}

