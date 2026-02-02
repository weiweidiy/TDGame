using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using System;
//using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Tiktok
{
    public class CustomCertificateHandler : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            // 这里可以添加自定义的证书验证逻辑，或者直接返回true来接受所有证书
            return true;
        }
    }

    public class TiktokUnityHttpRequest : UnityHttpRequest
    {


        ISerializer serializer;
        IDeserializer deserializer;
        string serverUrl;
        public TiktokUnityHttpRequest(ISerializer serializer, IDeserializer deserializer, [Inject("ServerUrl")]string serverUrl)
        {
            this.serializer = serializer;
            this.deserializer = deserializer;
            this.serverUrl = serverUrl;
        }


        public void SetToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                RemoveHeader("Authorization");
            }
            else
            {
                AddHeader("Authorization", $"Bearer {token}");
            }
        }

        public async Task<TResp> PostBodyAsync<TReq,TResp>(string url, TReq body, Encoding encoding = null, IRunable runable = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            string json = null;
            if (body != null)
            {
                json = serializer.Serialize(body);
            }

            runable?.Start(null);
            var result = await PostAsync(url, json, encoding);
            runable?.Stop();
            var response = encoding.GetString(result);
            TResp responseObject = deserializer.ToObject<TResp>(response);
            return responseObject;
        }


        public async Task<AccountDTO> RequestLogin(string deviceUid, IRunable runable = null)
        {
            var url = $"{serverUrl}Account/FastLogin";
            var body = new AccountDTO
            {
                Uid = deviceUid
            };
            runable?.Start(null);
            AccountDTO response = null;
            try
            {
                response = await PostBodyAsync<AccountDTO, AccountDTO>(url, body);
            }
            catch(Exception)
            {
                runable?.Stop();
                throw;
            }
            
            if (response == null)
            {
                throw new System.Exception("Login failed, response is null");
            }
            return response;
        }

        public async Task<ResponseGame> RequestEnterGame(AccountDTO accountDTO)
        {
            var url = $"{serverUrl}api/Game/EnterGame";
            SetToken(accountDTO.Token);
            var result = await PostAsync(url);
            var response = Encoding.UTF8.GetString(result);
            var responseObject = deserializer.ToObject<ResponseGame>(response);
            return responseObject;

        }

        /// <summary>
        /// 请求战斗
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<ResponseFight> RequestFight(RequestFight req)
        {
            var url = $"{serverUrl}api/Fight/Fight";
         
            var response = await PostBodyAsync<RequestFight, ResponseFight>(url, req);
            if (response == null)
            {
                throw new System.Exception("Login failed, response is null");
            }
            return response;
        }

        /// <summary>
        /// 请求抽卡
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseDraw> RequestDraw(RequestDrawSamurai req)
        {

            var url = $"{serverUrl}api/DrawSamurai/Draw";
            try
            {
                var response = await PostBodyAsync<RequestDrawSamurai, ResponseDraw>(url, req);
                if (response == null)
                {
                    throw new System.Exception("Draw failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        /// <summary>
        /// 布阵请求
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseDeploy> RequestDeploy(RequestDeploy req)
        {
            var url = $"{serverUrl}api/DeploySamurai/Deploy";
            try
            {
                var response = await PostBodyAsync<RequestDeploy, ResponseDeploy>(url, req);
                if (response == null)
                {
                    throw new System.Exception("Deploy failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        /// <summary>
        /// 请求改变阵型
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseChangeFormation> RequestChangeFormation(RequestChangeFormation req)
        {
            var url = $"{serverUrl}api/Formation/SelectFormation";
            try
            {
                var response = await PostBodyAsync<RequestChangeFormation, ResponseChangeFormation>(url, req);
                if (response == null)
                {
                    throw new System.Exception("Deploy failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        public async Task<ResponseCompleteGuideStep> RequestCompleteGuideStep(RequestCompleteGuideStep req)
        {
            var url = $"{serverUrl}api/GuideStep/CompleteGuideStep";
            try
            {
                var response = await PostBodyAsync<RequestCompleteGuideStep, ResponseCompleteGuideStep>(url, req);
                if (response == null)
                {
                    throw new System.Exception("Deploy failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseUpgradeBuilding> RequestUpgradeBuilding(RequestUpgradeBuilding req)
        {
            var url = $"{serverUrl}api/Building/Upgrade";
            try
            {
                var response = await PostBodyAsync<RequestUpgradeBuilding, ResponseUpgradeBuilding>(url, req);
                if (response == null)
                {
                    throw new System.Exception("UpgradeBuilding failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        /// <summary>
        /// 创建建筑
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseCreateBuilding> RequestCreateBuilding(RequestCreateBuilding req)
        {
            var url = $"{serverUrl}api/Building/Create";
            try
            {
                //Debug.Log("req: " + req.BuildingBusinessId);
                var response = await PostBodyAsync<RequestCreateBuilding, ResponseCreateBuilding>(url, req);
                if (response == null)
                {
                    throw new System.Exception("CreateBuilding failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        public async Task<ResponseUpgradeBuilding> RequestUpgradeBuildingImmediately(RequestUpgradeBuilding req)
        {
            var url = $"{serverUrl}api/Building/UpgradeImmediately";
            try
            {
                var response = await PostBodyAsync<RequestUpgradeBuilding, ResponseUpgradeBuilding>(url, req);
                if (response == null)
                {
                    throw new System.Exception("UpgradeBuilding failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        public async Task<ResponseMatch> RequestMatch(RequestMatch req)
        {
            var url = $"{serverUrl}api/Match/Match";
            try
            {
                var response = await PostBodyAsync<RequestMatch, ResponseMatch>(url, req);
                if (response == null)
                {
                    throw new System.Exception("RequestMatch failed, response is null");
                }
                return response;
            }
            catch (HttpResponseException ex)
            {
                // 解析服务器返回的错误信息
                var errorJson = ex.ResponseText;
                string message = null;
                try
                {
                    // 用你自己的反序列化工具
                    var errorObj = deserializer.ToObject<ErrorMessage>(errorJson);
                    message = errorObj?.message;
                }
                catch
                {
                    // 解析失败
                    throw new Exception(message ?? ex.Message);
                }
                throw new Exception(message ?? ex.Message);
            }
        }

        public class ErrorMessage
        {
            public string message;
        }
    }
}