using JFramework;
using System;

namespace Game.Share
{
    public class BuildingUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.BuildingUpdateNtf; }
        public BuildingDTO BuildingDTO { get; set; }
    }
}