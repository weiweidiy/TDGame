using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class SamuraisModel : BaseDictionaryModel<SamuraiDTO>
    {
        public class EventUpdate : Event { }
        public SamuraisModel(Func<SamuraiDTO, string> keySelector, EventManager eventManager) : base(keySelector, eventManager)
        {
        }

        public void Initialize(List<SamuraiDTO> samurais)
        {
            AddRange(samurais);
        }

        public void UpdateSamurai(List<SamuraiDTO> samuraiDTOs)
        {
            Clear();
            AddRange(samuraiDTOs);
            SendEvent<EventUpdate>(samuraiDTOs);
        }
    }

}
