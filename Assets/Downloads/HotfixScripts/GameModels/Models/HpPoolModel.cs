using Game.Share;
using JFramework;
using JFramework.Game;
using System;


namespace Tiktok
{
    public class HpPoolModel : BaseModel<HpPoolDTO>
    {
        public class EventUpdate : Event { }
        public HpPoolModel(EventManager eventManager) : base(eventManager)
        {
        }

        public void UpdateHpPool(HpPoolDTO hpPoolDTO)
        {
            data = hpPoolDTO;
            SendEvent<EventUpdate>(hpPoolDTO);
        }
    }

}
