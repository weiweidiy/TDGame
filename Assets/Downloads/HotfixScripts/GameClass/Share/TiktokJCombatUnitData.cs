using JFramework.Game;
using System.Collections.Generic;

namespace Game.Share
{
    public class TiktokJCombatUnitData : IJCombatUnitData
    {
        public  string Uid { get; set; }
        public int Seat { get; set; }
        public  string SamuraiBusinessId { get; set; }
        public  string SoldierBusinessId { get; set; } // 可能需要在其他地方使用
        public int CurHp { get; set; }
        public int MaxHp { get; set; }
        public List<KeyValuePair<string, string>> Actions { get; set; } //Key:uid  value:businessId
    }
}


