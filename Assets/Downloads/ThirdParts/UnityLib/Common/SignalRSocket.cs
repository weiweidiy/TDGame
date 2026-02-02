using JFramework;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common
{
    public class SignalRSocket : IJSocket
    {
        private HubConnection connection;
        private bool isOpen = false;
        private string url;

        public bool IsOpen => isOpen && connection != null && connection.State == HubConnectionState.Connected;

        public event Action<IJSocket> onOpen;
        public event Action<IJSocket, SocketStatusCodes, string> onClosed;
        public event Action<IJSocket, string> onError;
        public event Action<IJSocket, byte[]> onBinary;

        public void Init(string url, string token)
        {
            this.url = url;
            //connection = new HubConnectionBuilder()
            //    .WithUrl(url)
            //    .WithAutomaticReconnect()
            //    .Build();

            connection = new HubConnectionBuilder()
                            .WithUrl(url, options =>
                            {
                                options.AccessTokenProvider = () => Task.FromResult(token);
                            })
                            .WithAutomaticReconnect()
                            .Build();

            // 假设服务器端有 "ReceiveBinary" 方法用于接收二进制数据
            connection.On<byte[]>("ReceiveBinary", (data) =>
            {
                Cysharp.Threading.Tasks.UniTask.Post(() =>
                {
                    onBinary?.Invoke(this, data);
                });

                //onBinary?.Invoke(this, data);
            });

            connection.Closed += async (error) =>
            {
                isOpen = false;
                onClosed?.Invoke(this, SocketStatusCodes.NormalClosure, error?.Message ?? "Closed");
                await Task.CompletedTask;
            };

            connection.Reconnected += async (connectionId) =>
            {
                isOpen = true;
                onOpen?.Invoke(this);
                await Task.CompletedTask;
            };

            connection.Reconnecting += async (error) =>
            {
                isOpen = false;
                onError?.Invoke(this, error?.Message ?? "Reconnecting");
                await Task.CompletedTask;
            };
        }

        public async void Open()
        {
            if (connection == null)
            {
                onError?.Invoke(this, "Connection not initialized.");
                return;
            }
            try
            {
                await connection.StartAsync();
                isOpen = true;
                onOpen?.Invoke(this);
            }
            catch (Exception ex)
            {
                isOpen = false;
                onError?.Invoke(this, ex.Message);
            }
        }

        public async void Close()
        {
            if (connection == null) return;
            try
            {
                await connection.StopAsync();
                isOpen = false;
                onClosed?.Invoke(this, SocketStatusCodes.NormalClosure, "Closed by client");
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, ex.Message);
            }
        }

        public async void Send(byte[] data)
        {
            if (!IsOpen)
            {
                onError?.Invoke(this, "Connection is not open.");
                return;
            }
            try
            {
                // 假设服务器端有 "SendBinary" 方法用于接收二进制数据
                await connection.InvokeAsync("SendBinary", data);
            }
            catch (Exception ex)
            {
                onError?.Invoke(this, ex.Message);
            }
        }
    }
}