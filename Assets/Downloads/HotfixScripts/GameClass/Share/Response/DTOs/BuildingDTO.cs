using System;

namespace Game.Share
{
    public class BuildingDTO
    {
        //public required int Id { get; set; }
        public string BusinessId { get; set; }
        public int Level { get; set; }
        public DateTime? UpgradeEndTime { get; set; }
    }
}