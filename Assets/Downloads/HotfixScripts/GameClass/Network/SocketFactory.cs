using Adic;
using Adic.Container;
using JFramework;
using JFramework.Game;

namespace Tiktok
{
    public class SocketFactory : ISocketFactory
    {
        [Inject]
        IInjectionContainer container;

        public IJSocket Create()
        {
            var socket = container.Resolve<IJSocket>();
            return socket;

            //return new FakeSocket(tiktokConfigManager, dataManager);
        }
    }
}

