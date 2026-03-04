using JFramework.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class MatchFightController : Controller
    {
        public override async Task Do(GameContext context, params object[] parameters)
        {
            var httpRequest = context.Facade.GetHttpRequest();
            ResMatch matchTask = null;
            var url = parameters[0] as string;
            var req = parameters[1] as ReqMatch;
            try
            {
                matchTask = await httpRequest.HttpRequestAsync<ReqMatch, ResMatch>(url, req);
            }
            catch (Exception e)
            {
                Debug.LogError($"匹配失败，错误信息：{e.Message}");
                throw;
            }
            Debug.Log($"匹配成功 IP：{matchTask.Ip} 端口：{matchTask.Port}");
        }

    }
}