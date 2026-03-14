using JFramework;
using System;

namespace Game
{
    public class StartFightNtf : JNetMessage
    {
        public override string Uid { get; set; } = Guid.NewGuid().ToString();
        public override int TypeId { get => (int)ProtocolType.StartFightNtf; }

        public ushort Port { get; set; }
    }
}