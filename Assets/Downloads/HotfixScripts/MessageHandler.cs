using JFramework;
using JFramework.Unity;
using System;
using UnityEngine;


namespace Game
{
    public class MessageHandler : BaseNetworkMessageHandler
    {
        public override void Handle(IJNetMessage message)
        {
            switch(message.TypeId)
            {
                case (int)ProtocolType.HpPoolUpdateNtf:
                    {
                        //var ntf = message as HpPoolUpdateNtf;
                        //Debug.Log($"HpPoolUpdateNtf: {ntf.HpPoolDTO.Hp}");
                    }
                    break;
                default:
                    throw new Exception($"Unknown message type: {message.TypeId}");
            }
        }
    }
}

