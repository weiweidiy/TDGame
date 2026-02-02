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
    public class CastleBuildingsViewController : ViewController
    {
        public class EventBuildingClicked : Event { }

        public class  ControllerArgs : ControllerBaseArgs
        {
            public GameObject goTarget;
            public string targetBusinessId;
        }

        [Inject]
        TiktokConfigManager configManager;
        [Inject]
        BuildingModel buildingModel;
        [Inject]
        TiktokGameObjectManager gameObjectManager;
        [Inject]
        CastleBackgroundViewController backgroundViewController;

        [Inject]
        TiktokGameDataManager gameDataManager;

        /// <summary>
        /// 通过businessId查找对应的clickhandler
        /// </summary>
        Dictionary<string, IClickHandler> dicBuildings = new Dictionary<string, IClickHandler>();

        /// <summary>
        /// 建筑物唯一ID与实例化对象的映射 key:hashCode
        /// </summary>
        Dictionary<BuildingInfoView, string> dicBuildingUid = new Dictionary<BuildingInfoView, string>();

        public CastleBuildingsViewController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<CastleBackgroundViewController.EventEnterCastle>(OnEnterCastle);

            eventManager.AddListener<BuildingModel.EventUpdate>(OnBuildingUpdate);
            eventManager.AddListener<BuildingModel.EventCreate>(OnBuildingCreate);
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<CastleBackgroundViewController.EventEnterCastle>(OnEnterCastle);

            eventManager.RemoveListener<BuildingModel.EventUpdate>(OnBuildingUpdate);
            eventManager.RemoveListener<BuildingModel.EventCreate>(OnBuildingCreate);

            ReturnRentObjects();
        }

        #region Get方法集
        BuildingInfoView GetBuildingInfoView(string businessId)
        {
            foreach(var kv in dicBuildingUid)
            {
                var buildingInfoView = kv.Key;
                var uid = kv.Value;
                if(uid == businessId)
                {
                    return buildingInfoView;
                }
            }
            return null;
        }
        #endregion


        #region 模型事件

        private void OnBuildingCreate(BuildingModel.EventCreate e)
        {
            var dto = e.Body as BuildingDTO;
            var cfgData = configManager.Get<BuildingsCfgData>(dto.BusinessId);
            CreateBuilding(dto, cfgData.PositionIndex);
        }

        /// <summary>
        /// 建筑更新了
        /// </summary>
        /// <param name="e"></param>
        private void OnBuildingUpdate(BuildingModel.EventUpdate e)
        {
            var dto = e.Body as BuildingDTO;
            var businessId = dto.BusinessId;
            var endTime = dto.UpgradeEndTime;
            var now = gameDataManager.GetServerTime();

           // Debug.LogError($"now:{now}    endTime :{endTime}");

            int remainSeconds = 0;
            if (endTime.HasValue)
            {
                // endTime.Value 为 DateTime，now 为毫秒时间戳
                var endTimestamp = new DateTimeOffset(endTime.Value).ToUnixTimeMilliseconds();
                remainSeconds = (int)((endTimestamp - now) / 1000);
                if (remainSeconds < 0) remainSeconds = 0;
            }

            var buildingInfoView = GetBuildingInfoView(businessId);
            if(buildingInfoView != null)
            {
                var buildingInfo = new BuildingInfo()
                {
                    level = dto.Level,
                    remainTime = remainSeconds,
                };
                buildingInfoView.Refresh(buildingInfo);
            }
        }
        #endregion

        #region 控制器事件
        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;
            //EnterCastle();
        }
        /// <summary>

        private void OnEnterCastle(CastleBackgroundViewController.EventEnterCastle e)
        {
            //Debug.Log("进入城堡" + DateTime.Now);
            var cfgDataList = configManager.GetAll<BuildingsCfgData>();
            foreach (var cfgData in cfgDataList)
            {
                var buildingBusinessId = cfgData.Uid.ToString();
                var posIndex = cfgData.PositionIndex;
                var dto = buildingModel.Get(buildingBusinessId);
                if(dto != null)
                {
                    CreateBuilding(dto, posIndex);
                }
            }
        }
        #endregion

        #region panel事件
        private void OnClick(object obj)
        {
            Debug.Log("点击建筑物 " +(obj as GameObject).name );
            var controller = new ControllerArgs()
            {
                goTarget = obj as GameObject,
                targetBusinessId = dicBuildingUid[(obj as GameObject).GetComponent<BuildingInfoView>()]
            };
            SendEvent<EventBuildingClicked>(controller);
        }
        #endregion

        void CreateBuilding(BuildingDTO dto, int posIndex)
        {
            var buildingBusinessId = dto.BusinessId;
            var prefabPath = configManager.GetBuildingPrefabName(buildingBusinessId);
            var goBuilding = gameObjectManager.Rent(prefabPath);

            // 设置位置
            var parent = backgroundViewController.GetNode(posIndex);
            goBuilding.transform.SetParent(parent);
            goBuilding.transform.localPosition = Vector3.zero;
            var clickHandler = goBuilding.GetComponent<IClickHandler>();
            clickHandler.TargetArg = goBuilding;
            clickHandler.onClicked += OnClick;
            var buildingInfoView = goBuilding.GetComponent<BuildingInfoView>();

            var endTime = dto.UpgradeEndTime;
            var now = gameDataManager.GetServerTime();
            //Debug.LogError($"now:{now}    endTime :{endTime}");
            int remainSeconds = 0;
            if (endTime.HasValue)
            {
                // endTime.Value 为 DateTime，now 为毫秒时间戳
                var endTimestamp = new DateTimeOffset(endTime.Value).ToUnixTimeMilliseconds();
                remainSeconds = (int)((endTimestamp - now) / 1000);
                if (remainSeconds < 0) remainSeconds = 0;
            }

            var buildingInfo = new BuildingInfo()
            {
                level = dto.Level,
                remainTime = remainSeconds,
            };

            buildingInfoView.Refresh(buildingInfo);
            dicBuildings.Add(buildingBusinessId, clickHandler);
            dicBuildingUid.Add(buildingInfoView, buildingBusinessId);
        }
        void ReturnRentObjects()
        {
            foreach (var kv in dicBuildings)
            {
                var clickHandler = kv.Value;
                var targetGo = clickHandler.TargetArg as GameObject;
                clickHandler.onClicked -= OnClick;
                gameObjectManager.Return(kv.Value.TargetArg as GameObject);
                clickHandler.TargetArg = null;
            }
            dicBuildings.Clear();
            dicBuildingUid.Clear();
        }
    }
}
