using Cysharp.Threading.Tasks;
using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class AccountDTO
    {
        public string Uid { get; set; }

        public string Token { get; set; }
    }

    public class LoginController : Controller
    {
        public override async Task Do(GameContext context, params object[] parameters)
        {
            var httpRequest = context.Facade.GetHttpRequest();
            AccountDTO loginTask = null;
            var url = parameters[0] as string;
            var req = parameters[1] as AccountDTO;
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

            var transition = await context.Facade.TransitonOut(TransitionType.SMFadeTransition.ToString());
            await context.Facade.GetSceneStateMachine().SwitchToState(DemoSceneType.SceneCastle.ToString(), context).AsTask();
            await context.Facade.TransitonIn(transition);
        }
    }

}