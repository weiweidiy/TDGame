using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using Event = JFramework.Event;


namespace Tiktok
{
    /// <summary>
    /// 游戏关卡控制器
    /// </summary>
    public class GameLevelBackgroundViewController : ViewController
    {
        //public class Open : Event { }
        public class EventEnterLevel : Event { }

        public class  ControllerArgs : ControllerBaseArgs
        {
            public string levelBusinessId;
        }


        [Inject]
        TiktokConfigManager jConfigManager;

        [Inject]
        LevelsModel levelsMode;

        [Inject]
        TiktokGameObjectManager gameObjectManager;

        [Inject]
        ITransitionProvider transitionProvider;

        /// <summary>
        /// 当前租用的背景视图
        /// </summary>
        TiktokBackgroundView curRentBackgroundView;


        [Inject]
        public GameLevelBackgroundViewController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<LevelsModel.EventLevelNodeUpdate>(OnLevelNodeUpdate);
            eventManager.AddListener<EventSwitchLevel>(OnSwitchLevel);

        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<LevelsModel.EventLevelNodeUpdate>(OnLevelNodeUpdate);
            eventManager.RemoveListener<EventSwitchLevel>(OnSwitchLevel);

            ReturnRentObjects();
        }




        #region 对外接口

        /// <summary>
        /// 进入指定关卡
        /// </summary>
        /// <param name="uid"></param>
        public void EnterLevel(string uid)
        {
            var cfgData = jConfigManager.Get<LevelsCfgData>(uid);
            var textures = cfgData.Textures;
            var prefabData = jConfigManager.Get<PrefabsCfgData>(cfgData.PrefabUid);
            //租用背景预制体，需要归还
            var goLevel = gameObjectManager.Rent(prefabData.PrefabName);
            goLevel.transform.parent = gameObjectManager.GoRoot.transform;
            curRentBackgroundView = goLevel.GetComponent<TiktokBackgroundView>();
            //Debug.Log("eventManager.Raise<EventEnterLevel> " + uid);
            eventManager.Raise<EventEnterLevel>(uid); //通知其他控制器
        }

        /// <summary>
        /// 退出当前关卡
        /// </summary>
        public void ExitCurLevel()
        {
            ReturnRentObjects();
            eventManager.Raise<EventExitLevel>(null);
        }

        /// <summary>
        /// 获取指定节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Transform GetNode(int index)
        {
            return curRentBackgroundView.GetNode(index);
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        public Transform GetRoot() => curRentBackgroundView.transform;
        #endregion

        /// <summary>
        /// 归还租用的对象
        /// </summary>
        void ReturnRentObjects()
        {
            if (curRentBackgroundView != null)
                gameObjectManager.Return(curRentBackgroundView.gameObject);

            curRentBackgroundView = null;
        }


        #region 外部事件响应

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;
            EnterLevel(controllerArgs.levelBusinessId);
        }

        private async void OnSwitchLevel(EventSwitchLevel e)
        {
            var targetUid = (string)e.Body;

            var transition = await transitionProvider.InstantiateAsync(TransitionType.SMBlindsTransition.ToString());
            await transition.TransitionOut();
            ExitCurLevel();
            EnterLevel(targetUid);
            await transition.TransitionIn();
        }

        private void OnLevelNodeUpdate(LevelsModel.EventLevelNodeUpdate e)
        {
            var nodes = e.Body as List<LevelNodeDTO>;
        }
        #endregion
    }
}
