//using Adic;
//using JFramework;
//using JFramework.Extern;
//using JFramework.Game;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Tiktok
//{
//    public class FakeSocket : IJSocket
//    {
//        public bool IsOpen => true;

//        public event Action<IJSocket> onOpen;
//        public event Action<IJSocket, SocketStatusCodes, string> onClosed;
//        public event Action<IJSocket, string> onError;
//        public event Action<IJSocket, byte[]> onBinary;

//        FakeServer fakeServer;

//        [Inject]
//        public void Initialize(FakeServer fakeServer)
//        {
//            this.fakeServer = fakeServer;
//        }

//        public void Close()
//        {
//            //throw new NotImplementedException();
//        }

//        public void Init(string url)
//        {
//            //throw new NotImplementedException();
//        }

//        public void Open()
//        {
//            //throw new NotImplementedException();
//            onOpen?.Invoke(this);
//        }

//        public async void Send(byte[] data)
//        {
//            //throw new NotImplementedException();

//            var response = await fakeServer.OnRevieveData(data);

//            onBinary?.Invoke(this, response);
//        }

//        public void Recieve(byte[] data)
//        {
//            onBinary?.Invoke(this, data);
//        }
 
//    }
//}

