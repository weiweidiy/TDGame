using JFramework;
using System;
using System.Collections.Generic;

namespace Game
{
    public class AutoNetMessageRegister : ITypeRegister
    {
        public Dictionary<int, Type> GetTypes()
        {
            var tables = new Dictionary<int, Type>();
            tables.Add((int)ProtocolType.CurrencyUpdateNtf, typeof(CurrencyUpdateNtf));
            tables.Add((int)ProtocolType.StartFightNtf, typeof(StartFightNtf));
            return tables;
        }
    }
}
