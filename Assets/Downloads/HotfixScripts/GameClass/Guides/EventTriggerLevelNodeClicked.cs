using Game.Common;


namespace Tiktok
{
    public class EventTriggerLevelNodeClicked : BaseEventTrigger
    {
        public string TargetLevelNodeBusinessId { get; set; }
        public override void AddListeners()
        {

            eventManager.AddListener<GameLevelNodeViewController.EventLevelNodeClicked>(OnLevelNodeClicked);
        }

        public override void RemoveListeners()
        {

            eventManager.RemoveListener<GameLevelNodeViewController.EventLevelNodeClicked>(OnLevelNodeClicked);
        }

        private void OnLevelNodeClicked(GameLevelNodeViewController.EventLevelNodeClicked e)
        {
            var panelData = e.Body as GameLevelNodeViewController.PanelData;
            var levelNodeBusinessId = panelData.businessId;
            if (levelNodeBusinessId == TargetLevelNodeBusinessId)
            {
                Trigger(levelNodeBusinessId);
            }
        }
    }
}

