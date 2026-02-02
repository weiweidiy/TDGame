using Game.Common;
using JFramework.Game.View;


namespace Tiktok
{
    public class EventTriggerLevelNodeConfirmed : BaseEventTrigger
    {
        public string TargetLevelNodeBusinessId { get; set; }
        public override void AddListeners()
        {
            eventManager.AddListener<UILevelNodeMenuController.UIControllerEventAttackClicked>(OnEnterLevelNodeConfirmed);
        }

        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UILevelNodeMenuController.UIControllerEventAttackClicked>(OnEnterLevelNodeConfirmed);
        }

        private void OnEnterLevelNodeConfirmed(UILevelNodeMenuController.UIControllerEventAttackClicked e)
        {
            var levelNodeBusinessId = e.Body as string;
            if (levelNodeBusinessId == TargetLevelNodeBusinessId)
            {
                //Debug.Log("引导第二步完成");
                var controllerArgs = new UIGuideController.ControllerArgs
                {
                    panelName = nameof(UIPanelGuideMask),
                };
                eventManager.Raise<UIGuideController.Close>(controllerArgs);
                //Stop();
                Trigger(levelNodeBusinessId);
            }
        }
    }
}

