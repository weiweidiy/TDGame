using JFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiktok;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Common
{
    public class HttpResponseException : Exception
    {
        public string ResponseText { get; }
        public long StatusCode { get; }

        public HttpResponseException(string message, string responseText, long statusCode)
            : base(message)
        {
            ResponseText = responseText;
            StatusCode = statusCode;
        }
    }

    public class UnityHttpRequest : IHttpRequest
    {
        private Dictionary<string, string> headers = new Dictionary<string, string>();
        private string contentType = "application/json";

        public void AddHeader(string name, string value)
        {
            if (headers.ContainsKey(name))
            {
                headers[name] = value;
            }
            else
            {
                headers.Add(name, value);
            }
        }

        public void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                AddHeader(header.Key, header.Value);
            }
        }

        public void SetContentType(string contentType)
        {
            this.contentType = contentType;
        }

        public byte[] Get(string url, Encoding encoding = null)
        {
            return GetAsync(url, encoding).GetAwaiter().GetResult();
        }

        public async Task<byte[]> GetAsync(string url, Encoding encoding = null)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                SetupRequest(webRequest);
                await SendRequest(webRequest);
                return webRequest.downloadHandler.data;
            }
        }

        public byte[] Post(string url, Dictionary<string, string> dic, Encoding encoding = null)
        {
            return PostAsync(url, dic, encoding).GetAwaiter().GetResult();
        }

        public byte[] Post(string url, string content = null, Encoding encoding = null)
        {
            return PostAsync(url, content, encoding).GetAwaiter().GetResult();
        }

        public async Task<byte[]> PostAsync(string url, Dictionary<string, string> dic, Encoding encoding = null)
        {
            WWWForm form = new WWWForm();
            foreach (var kvp in dic)
            {
                form.AddField(kvp.Key, kvp.Value);
            }

            using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
            {
                webRequest.certificateHandler = new CustomCertificateHandler();
                SetupRequest(webRequest);
                await SendRequest(webRequest);
                return webRequest.downloadHandler.data;
            }
        }

        public async Task<byte[]> PostAsync(string url, string content = null, Encoding encoding = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
            {
                webRequest.certificateHandler = new CustomCertificateHandler();
                if (!string.IsNullOrEmpty(content))
                {
                    byte[] bodyRaw = (encoding ?? Encoding.UTF8).GetBytes(content);
                    webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                }
                webRequest.downloadHandler = new DownloadHandlerBuffer();

                SetupRequest(webRequest);
                webRequest.SetRequestHeader("Content-Type", contentType);
                await SendRequest(webRequest);
                return webRequest.downloadHandler.data;
            }
        }

        public byte[] Delete(string url)
        {
            return DeleteAsync(url).GetAwaiter().GetResult();
        }

        public async Task<byte[]> DeleteAsync(string url)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Delete(url))
            {
                SetupRequest(webRequest);
                await SendRequest(webRequest);
                return webRequest.downloadHandler?.data ?? new byte[0];
            }
        }

        public void RemoveHeader(string name)
        {

            if (headers.ContainsKey(name))
            {
                headers.Remove(name);
            }
        }

        private void SetupRequest(UnityWebRequest webRequest)
        {
            foreach (var header in headers)
            {
                webRequest.SetRequestHeader(header.Key, header.Value);
            }
        }

        private async Task SendRequest(UnityWebRequest webRequest)
        {
            var operation = webRequest.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                // 抛出自定义异常，带上响应内容
                throw new HttpResponseException(
                    $"HTTP Request failed: {webRequest.error}\nURL: {webRequest.url}",
                    webRequest.downloadHandler?.text,
                    webRequest.responseCode
                );

                //throw new Exception($"HTTP Request failed: {webRequest.error}\nURL: {webRequest.url}\nResponse: {webRequest.downloadHandler?.text}");
            }
        }
    }
}