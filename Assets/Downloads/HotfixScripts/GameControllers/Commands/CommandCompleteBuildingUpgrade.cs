using Adic;
using Adic.Container;
using dnlib.DotNet;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using Tiktok;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GameCommands
{
    public class CommandCompleteBuildingUpgrade : Command
    {
        [Inject]
        IInjectionContainer container;
        [Inject]
        TiktokUnityHttpRequest httpRequest;
        [Inject]
        IObjectPool classPool;
        [Inject]
        EventManager eventManager;
        public override async void Execute(params object[] parameters)
        {

            this.Retain();
            var buildingBusinessId = (string)parameters[0];
            var req = classPool.Rent<RequestUpgradeBuilding>();
            req.BuildingBusinessId = buildingBusinessId;
            ResponseUpgradeBuilding result = null;
            try
            {
                result = await httpRequest.RequestUpgradeBuildingImmediately(req);
            }
            catch (Exception e)
            {
                var uiArg = container.Resolve<UIWarningMessageController.ControllerArgs>();
                uiArg.Message = e.Message;
                uiArg.Type = UIWarningMessageController.WarningType.Error;
                uiArg.panelName = nameof(UIPanelWarningMessage);
                eventManager.Raise<UIWarningMessageController.Open>(uiArg);
                Debug.LogError(e.Message);
            }
            classPool.Return(req);

            
            //临时测试用
            try
            {
                var request = classPool.Rent<RequestMatch>();
                var match = await httpRequest.RequestMatch(request);
                Debug.Log("升级完成，开始匹配战斗，战斗ID：" + match.Ip + "/" + match.Port);
                classPool.Return(request);

                var asyn = SceneManager.UnloadSceneAsync("SceneCastle");
                asyn.completed += (operation) =>
                {
                    Debug.Log("卸载CastleScene完成");
                };

                GlobalBoard.Ip = "127.0.0.1";
                GlobalBoard.Port = 7777;
                var asyn2 = SceneManager.LoadSceneAsync("RoomScene",LoadSceneMode.Additive);
                asyn2.completed += (operation) =>
                {
                    Debug.Log("加载RoomScene完成");
                    Scene loadedScene = SceneManager.GetSceneByName("RoomScene");
                    if (loadedScene.IsValid() && loadedScene.isLoaded)
                    {
                        // 激活场景（设置为活动场景）
                        SceneManager.SetActiveScene(loadedScene);
                        Debug.Log("RoomScene已激活为活动场景");
                    }
                };


            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }


            this.Release();
        }
    }


}
