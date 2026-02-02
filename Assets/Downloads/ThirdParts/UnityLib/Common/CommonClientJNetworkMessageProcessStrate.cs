using Adic;
using JFramework;


namespace Game.Common
{
    public class CommonClientJNetworkMessageProcessStrate : JNetworkMessageProcessStrate
    {
        [Inject]
        public CommonClientJNetworkMessageProcessStrate(INetMessageSerializerStrate serializer, JDataProcesserManager outProcesser, JDataProcesserManager comingProcesser, [Inject("Client")] IMessageTypeResolver typeResolver) : base(serializer, typeResolver, outProcesser, comingProcesser)
        {
            
        }

     
    }

    public class CommonServerJNetworkMessageProcessStrate : JNetworkMessageProcessStrate
    {
        [Inject]
        public CommonServerJNetworkMessageProcessStrate(INetMessageSerializerStrate serializer, JDataProcesserManager outProcesser, JDataProcesserManager comingProcesser, [Inject("Server")] IMessageTypeResolver typeResolver) : base(serializer, typeResolver, outProcesser, comingProcesser)
        {

        }


    }
}

