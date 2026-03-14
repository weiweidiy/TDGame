using Cysharp.Threading.Tasks;
using JFramework;
using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;


namespace Game
{
    public class MessageHandler : BaseNetworkMessageHandler
    {
        public override async void Handle(IJNetMessage message)
        {
            switch(message.TypeId)
            {
                case (int)ProtocolType.HpPoolUpdateNtf:
                    {
                        //var ntf = message as HpPoolUpdateNtf;
                        //Debug.Log($"HpPoolUpdateNtf: {ntf.HpPoolDTO.Hp}");
                    }
                    break;
                case (int)ProtocolType.StartFightNtf:
                    {
                        var ntf = message as StartFightNtf;
                        var port = ntf.Port;
                        Debug.Log($"Received StartFightNtf, connecting to fight server at port {port}...");
                        GlobalBoard.Ip = "127.0.0.1";
                        GlobalBoard.Port = port;
                        await UniTask.Delay(3000); // 模拟连接服务器的延迟
                        Facade.GetSceneStateMachine().SwitchToState(DemoSceneType.RoomScene.ToString(), Facade.GetGameContext());
                    }
                    break;
                default:
                    throw new Exception($"Unknown message type: {message.TypeId}");
            }
        }
    }
}

