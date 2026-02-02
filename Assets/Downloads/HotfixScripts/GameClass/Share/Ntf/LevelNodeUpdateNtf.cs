using JFramework;
using System;

namespace Game.Share
{
    public class LevelNodeUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.LevelNodeUpdateNtf; }
        public LevelNodeDTO LevelNodeDTO { get; set; }
    }
}