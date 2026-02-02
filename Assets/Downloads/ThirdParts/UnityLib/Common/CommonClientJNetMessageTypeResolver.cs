using Adic;
using Game.Common;
using JFramework;
using System;
using System.Collections.Generic;
using Tiktok;

namespace Game.Common
{

    public class CommonClientJNetMessageTypeResolver : JNetMessageJsonTypeResolver
    {
        [Inject]
        public CommonClientJNetMessageTypeResolver(IDeserializer deserializer , [Inject("Client")] ITypeRegister register) : base(deserializer, register)
        {            
        }
    }

    public class CommonServerJNetMessageTypeResolver : JNetMessageJsonTypeResolver
    {
        [Inject]
        public CommonServerJNetMessageTypeResolver(IDeserializer deserializer, [Inject("Server")] ITypeRegister register) : base(deserializer, register)
        {
        }
    }
}

