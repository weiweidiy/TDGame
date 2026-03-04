using JFramework;
using System;

namespace Game
{
    public class HpPoolUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.HpPoolUpdateNtf; }
        public   HpPoolDTO HpPoolDTO { get; set; }
    }

    public class SamuraiUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.SamuraiUpdateNtf; }

    }
}