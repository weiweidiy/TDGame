using Game.Common;


namespace Tiktok
{
    public class EventTriggerDialogCompleted : BaseEventTrigger
    {
        public int DialogGroupId { get; set; }

        public override void AddListeners()
        {
            eventManager.AddListener<UIDialogController.EventDialogCompleted>(OnDialogComplete);
        }

        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UIDialogController.EventDialogCompleted>(OnDialogComplete);
        }

        private void OnDialogComplete(UIDialogController.EventDialogCompleted e)
        {
            var groupId = (int)e.Body;
            if (groupId == DialogGroupId)
            {
                Trigger(DialogGroupId);
            }
        }
    }
}

