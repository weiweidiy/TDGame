using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{

    public class GameLevelNodeBottomViewController : ViewController
    {
        [Inject]
        protected TiktokGameObjectManager gameObjectManager;

        [Inject]
        protected GameLevelBackgroundViewController gameLevelViewController;

        [Inject]
        protected TiktokConfigManager configManager;

        [Inject]
        protected LevelsModel levelsMode;

        protected Dictionary<string, GameObject> dicRentGameObjects = new Dictionary<string, GameObject>();

        string curLevelBusinessId = string.Empty;

        [Inject]
        public GameLevelNodeBottomViewController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<LevelsModel.EventLevelNodeUpdate>(OnLevelNodeUpdate);
            eventManager.AddListener<GameLevelBackgroundViewController.EventEnterLevel>(OnEnterLevel);
            eventManager.AddListener<EventExitLevel>(OnExitLevel);

            //SetStartComplete();
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<LevelsModel.EventLevelNodeUpdate>(OnLevelNodeUpdate);
            eventManager.RemoveListener<GameLevelBackgroundViewController.EventEnterLevel>(OnEnterLevel);
            eventManager.RemoveListener<EventExitLevel>(OnExitLevel);

            ClearRentObjects();
        }

        /// <summary>
        /// 节点更新了，可能是星星数更新了，或者是解锁了，由子类实现
        /// </summary>
        /// <param name="updatedNode"></param>
        protected virtual void UpdateNode(LevelNodeDTO updatedNode) { }


        #region 外部事件响应

        protected override void DoOpen(Open e)
        {
            
        }
        /// <summary>
        /// 响应关卡进入事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEnterLevel(GameLevelBackgroundViewController.EventEnterLevel e)
        {
            curLevelBusinessId = (string)e.Body;
            var allNodes = configManager.GetAll<LevelsNodesCfgData>();
            // Debug.LogError(allNodes.Count + "  " + tiktokConfigManager.GetHashCode());
            Debug.Log("OnEnterLevel " + GetType().ToString() );
            var nodes = levelsMode.GetUnlockedLevelNodes(curLevelBusinessId);
            foreach (var node in nodes)
            {
                
                ShowNode(node.BusinessId.ToString());
            }
        }

        /// <summary>
        /// 响应关卡退出事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExitLevel(EventExitLevel e)
        {
            curLevelBusinessId = string.Empty;
            ClearRentObjects();
        }

        /// <summary>
        /// 节点更新事件
        /// </summary>
        /// <param name="e"></param>
        private void OnLevelNodeUpdate(LevelsModel.EventLevelNodeUpdate e)
        {
            var data = e.Body as List<LevelNodeDTO>;
            foreach (var nodeDTO in data)
            {
                var levelNodeBusinessId = nodeDTO.BusinessId;
                if (!configManager.IsBelongToLevel(levelNodeBusinessId, curLevelBusinessId))
                    continue;

                if (IsShow(levelNodeBusinessId))
                {
                    //Debug.LogError("节点已经显示了 更新星星数" + nodeDTO.Process);
                    UpdateNode(nodeDTO);
                }
                else
                {
                    //判断uid是否是当前关卡的节点

                    ShowNode(levelNodeBusinessId);
                }
            }
        }
        #endregion

        #region 对外接口
        /// <summary>
        /// 显示多个节点
        /// </summary>
        /// <param name="nextNodesUid"></param>
        public void ShowNodes(List<string> nextNodesUid)
        {
            foreach (var uid in nextNodesUid)
            {
                ShowNode(uid);
            }
        }


        /// <summary>
        /// 显示节点
        /// </summary>
        /// <param name="uid"></param>
        public virtual void ShowNode(string uid)
        {
            var cfgData = configManager.Get<LevelsNodesCfgData>(uid);
            var bottomPrefabData = configManager.Get<PrefabsCfgData>(GetPrefabUid(cfgData));
            var nodeIndex = cfgData.NodeIndex;

            //创建底座
            var goBottom = gameObjectManager.Rent(bottomPrefabData.PrefabName);
            goBottom.transform.SetParent(gameLevelViewController.GetNode(nodeIndex));
            goBottom.transform.localPosition = Vector3.zero;
            dicRentGameObjects.Add(uid, goBottom);
        }

        /// <summary>
        /// 隐藏某个节点
        /// </summary>
        /// <param name="uid"></param>
        public virtual void HideNode(string uid)
        {
            var go = dicRentGameObjects[uid];
            dicRentGameObjects.Remove(uid);
            gameObjectManager.Return(go);
        }

        /// <summary>
        /// 节点是否已显示
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool IsShow(string uid)
        {
            return dicRentGameObjects.ContainsKey(uid);
        }

        #endregion

        #region 私有方法
        protected virtual string GetPrefabUid(LevelsNodesCfgData cfgData)
        {
            return cfgData.BottomPrefabUid;
        }

        void ClearRentObjects()
        {
            foreach (var go in dicRentGameObjects.Values)
            {
                gameObjectManager.Return(go);
            }

            dicRentGameObjects.Clear();
        }

        bool ContainsNodeId(List<LevelNodeDTO> nodes, string nodeUid)
        {
            foreach (var node in nodes)
            {
                if (node.BusinessId == nodeUid)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}
