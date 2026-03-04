using Cysharp.Threading.Tasks;
using JFramework;
using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class LoginController : Controller
    {
        public override async Task Do(GameContext context, params object[] parameters)
        {
            var httpRequest = context.Facade.GetHttpRequest();
            var network = context.Facade.GetNetworkManager();
            //todo:这里的accountDTO应该改成requestXXX，responseXXX，
            AccountDTO loginTask = null;
            var url = parameters[0] as string;
            var req = parameters[1] as AccountDTO;

            var urlEnter = parameters[2] as string;
            var reqEnter = parameters[3] as ReqEnterGame;

            var socketUrl = parameters[4] as string;

            Debug.Log($"开始登录，URL={url}，Uid={req.Uid}");
            try
            {
                loginTask = await httpRequest.HttpRequestAsync<AccountDTO, AccountDTO>(url, req);
            }
            catch (Exception e)
            {
                Debug.LogError($"登录失败，错误信息：{e.Message}");
                throw;

            }
            Debug.Log($"登录成功，Token={loginTask.Token}");
            SetToken(httpRequest, loginTask.Token);

            try
            {
                var enterGame = await httpRequest.HttpRequestAsync<ReqEnterGame, ResEnterGame>(urlEnter, reqEnter);
            }
            catch(Exception e)
            {
                Debug.LogError($"进入游戏失败，错误信息：{e.Message}");
                throw;
            }

            try
            {
                string hubUrl = socketUrl.TrimEnd('/') + "/gamehub";
                Debug.Log($"连接游戏服务器，URL={hubUrl}");
                await network.Connect(hubUrl, loginTask.Token);
            }
            catch(Exception e)
            {
                Debug.LogError($"连接游戏服务器失败，错误信息：{e.Message}");
                throw;
            }


            var transition = await context.Facade.TransitonOut(TransitionType.SMFadeTransition.ToString());
            await context.Facade.GetSceneStateMachine().SwitchToState(DemoSceneType.SceneCastle.ToString(), context).AsTask();
            await context.Facade.TransitonIn(transition);
        }

        public void SetToken(IHttpRequest http, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                http.RemoveHeader("Authorization");
            }
            else
            {
                http.AddHeader("Authorization", $"Bearer {token}");
            }
        }
    }

}