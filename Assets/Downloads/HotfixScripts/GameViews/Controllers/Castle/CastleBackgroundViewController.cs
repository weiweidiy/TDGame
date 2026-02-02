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
    public class CastleBackgroundViewController : ViewController
    {
        public class EventBuildingCreateClicked : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            //to do: add args if needed
            public string targetBusinessId;
        }
        public class EventEnterCastle : Event { }

        [Inject]
        TiktokConfigManager configManager;
        [Inject]
        BuildingModel buildingModel;
        [Inject]
        TiktokGameObjectManager gameObjectManager;
        /// <summary>
        /// 当前租用的背景视图
        /// </summary>
        TiktokBackgroundView curRentBackgroundView;

        [Inject]
        TiktokGameDataManager gameDataManager;

        Dictionary<string, IClickHandler> dicBuildingsHandlers = new Dictionary<string, IClickHandler>();

        Dictionary<string, GameObject> dicFingerObjects = new Dictionary<string, GameObject>();

        public CastleBackgroundViewController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<BuildingModel.EventCreate>(OnBuildingCreate);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<BuildingModel.EventCreate>(OnBuildingCreate);
            ReturnRentObjects();
        }

        private void OnBuildingCreate(BuildingModel.EventCreate e)
        {
            var dto = e.Body as BuildingDTO;
            ReturnFingerAndBuildingBottom(dto.BusinessId);
        }

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            EnterCastle();
        }

        /// <summary>
        /// 进入指定关卡
        /// </summary>
        /// <param name="uid"></param>
        void EnterCastle()
        {
            ////租用背景预制体，需要归还
            var goCastle = gameObjectManager.Rent(configManager.GetCastlePrefabName());
            goCastle.transform.parent = gameObjectManager.GoRoot.transform;
            curRentBackgroundView = goCastle.GetComponent<TiktokBackgroundView>();
            eventManager.Raise<EventEnterCastle>(null);

            var cfgDataList = configManager.GetAll<BuildingsCfgData>();
            foreach (var cfgData in cfgDataList)
            {
                var buildingBusinessId = cfgData.Uid.ToString();
                var posIndex = cfgData.PositionIndex;
                var canBuild = gameDataManager.CanBuildingBuild(buildingBusinessId);
                if (canBuild)
                {
                    Debug.Log("可以建造建筑物 " + buildingBusinessId);
                    var prefabPath = configManager.GetCanBuildPrefabName();
                    var bottomPrefabPath = configManager.GetCanBuildingBottomPrefabName(buildingBusinessId);
                    var goFinger = gameObjectManager.Rent(prefabPath);
                    var goBuildingBottom = gameObjectManager.Rent(bottomPrefabPath);
                    // 设置位置
                    var parent = GetNode(posIndex);
                    goFinger.transform.SetParent(parent);
                    goFinger.transform.localPosition = Vector3.zero;
                    goBuildingBottom.transform.SetParent(parent);
                    goBuildingBottom.transform.localPosition = Vector3.zero;
                    //监听点击事件
                    var clickHandler = goBuildingBottom.GetComponent<IClickHandler>();
                    clickHandler.TargetArg = buildingBusinessId;
                    clickHandler.onClicked += OnClick;
                    //缓存点击处理器，归还时使用
                    dicBuildingsHandlers.Add(buildingBusinessId, clickHandler);
                    dicFingerObjects.Add(buildingBusinessId, goFinger);
                }
            }

             
        }

        private void OnClick(object obj)
        {
            var buildingBusinessId = obj as string;
            Debug.Log("点击了可以建造的建筑物 " + buildingBusinessId);
            var controllerArgs = new ControllerArgs()
            {
                targetBusinessId = buildingBusinessId
            };
            SendEvent<EventBuildingCreateClicked>(controllerArgs);
        }

        /// <summary>
        /// 归还租用的对象
        /// </summary>
        void ReturnRentObjects()
        {
            foreach (var finger in dicFingerObjects)
            {
                gameObjectManager.Return(finger.Value);
            }
            dicFingerObjects.Clear();

            foreach (var handler in dicBuildingsHandlers.Values)
            {
                handler.onClicked -= OnClick;
                gameObjectManager.Return(((MonoBehaviour)handler).gameObject);
            }
            dicBuildingsHandlers.Clear();

            if (curRentBackgroundView != null)
                gameObjectManager.Return(curRentBackgroundView.gameObject);

            curRentBackgroundView = null;
        }

        void ReturnFingerAndBuildingBottom(string buildingBusinessId)
        {
            if (dicFingerObjects.TryGetValue(buildingBusinessId, out var goFinger))
            {
                gameObjectManager.Return(goFinger);
                dicFingerObjects.Remove(buildingBusinessId);
            }
            if (dicBuildingsHandlers.TryGetValue(buildingBusinessId, out var clickHandler))
            {
                clickHandler.onClicked -= OnClick;
                gameObjectManager.Return(((MonoBehaviour)clickHandler).gameObject);
                dicBuildingsHandlers.Remove(buildingBusinessId);
            }
        }

        public Transform GetNode(int index)
        {
            if(curRentBackgroundView != null)
                return curRentBackgroundView.GetNode(index);

            return null;
        }
    }
}
