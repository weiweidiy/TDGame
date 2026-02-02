using JFramework;
using System;
using System.Collections.Generic;

namespace Game.Share
{
    public class CurrencyUpdateNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.CurrencyUpdateNtf; }
        public List<CurrencyDTO> CurrencyDTOs { get; set; }
    }
}