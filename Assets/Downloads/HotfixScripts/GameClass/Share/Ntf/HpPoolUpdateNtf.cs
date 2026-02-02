using JFramework;
using System;

namespace Game.Share
{
    public class HpPoolUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.HpPoolUpdateNtf; }
        public   HpPoolDTO HpPoolDTO { get; set; }
    }
}