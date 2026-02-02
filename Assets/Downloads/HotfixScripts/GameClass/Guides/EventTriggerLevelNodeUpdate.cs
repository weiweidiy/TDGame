using Game.Common;
using Game.Share;
using System.Collections.Generic;


namespace Tiktok
{
    public class EventTriggerLevelNodeUpdate : BaseEventTrigger
    {
        public string targetLevelNodeBusinessId = string.Empty;
        public int targetLevelNodeProcess = 0;

        public override void AddListeners()
        {
            eventManager.AddListener<LevelsModel.EventLevelNodeUpdate>(OnNodeUpdate);
        }



        public override void RemoveListeners()
        {
            eventManager.RemoveListener<LevelsModel.EventLevelNodeUpdate>(OnNodeUpdate);
        }

        private void OnNodeUpdate(LevelsModel.EventLevelNodeUpdate e)
        {
            var dtos = e.Body as List<LevelNodeDTO>;
            foreach(var dto in dtos)
            {
                if(dto.BusinessId == targetLevelNodeBusinessId && dto.Process == targetLevelNodeProcess)
                {
                    Trigger(dto);
                }
            }
        }
    }
}

