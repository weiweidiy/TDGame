using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{

    public class StartFightController : Controller
    {
        public override async Task Do(GameContext context, params object[] parameters)
        {
            var httpRequest = context.Facade.GetHttpRequest();
            ResStartFight fightTask = null;
            var url = parameters[0] as string;
            var req = parameters[1] as ReqStartFight;

            try
            {
                fightTask = await httpRequest.HttpRequestAsync<ReqStartFight, ResStartFight>(url, req);
            }
            catch (Exception e)
            {
                Debug.LogError($"开始战斗失败，错误信息：{e.Message}");
                throw;

            }
            //Debug.Log($"登录成功，Token={fightTask.Token}");
        }
    }

}