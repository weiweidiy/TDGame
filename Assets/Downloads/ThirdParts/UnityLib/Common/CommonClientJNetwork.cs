using Adic;
using JFramework;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Common
{
    public class CommonClientJNetwork : JNetwork
    {
        [Inject]
        public CommonClientJNetwork(ISocketFactory socketFactory, IJTaskCompletionSourceManager<IUnique> taskManager, [Inject("Client")] INetworkMessageProcessStrate messageProcessStrate) : base(socketFactory, taskManager, messageProcessStrate)
        {

        }
    }
}

