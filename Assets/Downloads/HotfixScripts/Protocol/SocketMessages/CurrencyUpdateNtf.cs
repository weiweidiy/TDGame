using JFramework;
using System;

namespace Game
{


    public class CurrencyUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.CurrencyUpdateNtf; }
        public HpPoolDTO HpPoolDTO { get; set; }
    }
}