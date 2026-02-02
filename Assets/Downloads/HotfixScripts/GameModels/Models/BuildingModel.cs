using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class BuildingModel : BaseDictionaryModel<BuildingDTO>
    {
        public class EventCreate : Event { }
        public class EventUpdate : Event { }
        public BuildingModel(Func<BuildingDTO, string> keySelector, EventManager eventManager) : base(keySelector, eventManager)
        {
        }
        public void Initialize(List<BuildingDTO> buildings)
        {
            AddRange(buildings);
        }
        public void UpdateBuilding(BuildingDTO buildingDTO)
        {
            var data = Get(buildingDTO.BusinessId.ToString());
            if(data != null)
            {
                data.Level = buildingDTO.Level;
                data.UpgradeEndTime = buildingDTO.UpgradeEndTime;
                SendEvent<EventUpdate>(buildingDTO);
            }
            else
            {
                Add(buildingDTO);
                SendEvent<EventCreate>(buildingDTO);
            }
   
        }
    }

}
