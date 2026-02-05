using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using Event = JFramework.Event;


namespace Game.Modules
{
    public class BackgroundViewController : ViewController
    {
        //public class EventBuildingCreateClicked : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            //to do: add args if needed
            public string targetBusinessId;
            public string prefabName;
            public Transform parent;
        }
        public class EventEnterCastle : Event { }

        /// <summary>
        /// 游戏对象管理
        /// </summary>
        IGameObjectPool gameObjectManager;

        /// <summary>
        /// 当前租用的背景视图
        /// </summary>
        BackgroundView curRentBackgroundView;

        [Inject]
        public BackgroundViewController(EventManager eventManager, IGameObjectPool gameObjectManager) : base(eventManager)
        {
            this.gameObjectManager = gameObjectManager;
        }

        public override void OnStart()
        {
            base.OnStart();
            //eventManager.AddListener<BuildingModel.EventCreate>(OnBuildingCreate);
        }

        public override void OnStop()
        {
            base.OnStop();
            //eventManager.RemoveListener<BuildingModel.EventCreate>(OnBuildingCreate);
            ReturnRentObjects();
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            ShowBackground(controllerArgs);
        }

        /// <summary>
        /// 进入指定关卡
        /// </summary>
        /// <param name="uid"></param>
        void ShowBackground(ControllerArgs args)
        {
            ////租用背景预制体，需要归还
            var goCastle = gameObjectManager.Rent(args.prefabName,null);
            goCastle.transform.parent = args.parent;
            curRentBackgroundView = goCastle.GetComponent<BackgroundView>();
            eventManager.Raise<EventEnterCastle>(args);
             
        }

        /// <summary>
        /// 归还租用的对象
        /// </summary>
        void ReturnRentObjects()
        {
            if (curRentBackgroundView != null)
                gameObjectManager.Return(curRentBackgroundView.gameObject);

            curRentBackgroundView = null;
        }

        public Transform GetNode(int index)
        {
            if(curRentBackgroundView != null)
                return curRentBackgroundView.GetNode(index);

            return null;
        }
    }
}
