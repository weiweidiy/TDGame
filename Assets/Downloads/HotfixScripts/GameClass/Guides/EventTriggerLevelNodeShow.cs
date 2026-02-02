using Adic;
using Game.Common;
using Game.Share;
using System;
using System.Collections.Generic;


namespace Tiktok
{

    public class EventTriggerLevelNodeShow : BaseEventTrigger
    {
        public string targetLevelNodeBusinessId = string.Empty;
        public int targetLevelNodeProcess = 0;

        [Inject]
        LevelsModel levelsModel;

        public override void AddListeners()
        {
            eventManager.AddListener<GameLevelNodeViewController.EventNodeShow>(OnNodeShow);
        }

        public override void RemoveListeners()
        {
            eventManager.RemoveListener<GameLevelNodeViewController.EventNodeShow>(OnNodeShow);
        }

        private void OnNodeShow(GameLevelNodeViewController.EventNodeShow e)
        {
            var data = e.Body as GameLevelNodeViewController.PanelData;
            if (data == null) return;
            if(data.businessId == targetLevelNodeBusinessId)
            {
                var dto = levelsModel.Get(targetLevelNodeBusinessId);
                if (dto.Process == targetLevelNodeProcess)
                {
                    //Debug.Log("引导第一步开始");
                    Trigger(data);
                }
            }

        }
    }
}

