using Game.Common;
using System;


namespace Tiktok
{
    public class EventTriggerRewardReceived : BaseEventTrigger
    {
        //public string RewardId { get; set; }
        public override void AddListeners()
        {
            eventManager.AddListener<UIRewardController.EventRewardComplete>(OnRewardComplete);
        }

        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UIRewardController.EventRewardComplete>(OnRewardComplete);
        }

        private void OnRewardComplete(UIRewardController.EventRewardComplete e)
        {
            Trigger(null);
        }
    }
}

