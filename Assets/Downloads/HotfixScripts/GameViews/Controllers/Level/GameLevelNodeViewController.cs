using Adic;
using Adic.Container;
using Game.Common;
using Game.Share;
using GameCommands;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{
    /// <summary>
    /// 关卡节点视图控制器
    /// </summary>
    public class GameLevelNodeViewController : GameLevelNodeBottomViewController
    {
        public class EventNodeShow : JFramework.Event { }
        public class EventLevelNodeClicked : JFramework.Event { }


        public class PanelData
        {
            public TiktokLevelNodeView nodeView;
            public string businessId;
        }

        /// <summary>
        /// 当前关卡所有节点
        /// </summary>
        Dictionary<int, string> dicLevelNodesUid = new Dictionary<int, string>();

        [Inject]
        public GameLevelNodeViewController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStop()
        {
            OnExitLevel(null);

            base.OnStop();
        }


        protected override void OnExitLevel(EventExitLevel e)
        {
            foreach (var go in dicRentGameObjects.Values)
            {
                go.GetComponent<TiktokLevelNodeView>().onClicked -= NodeView_onClicked;
                //Debug.LogError("OnExitLevel");
            }

            base.OnExitLevel(e);
            dicLevelNodesUid.Clear();

        }

        /// <summary>
        /// 显示节点,
        /// </summary>
        /// <param name="businessId"></param>
        public override void ShowNode(string businessId)
        {
            base.ShowNode(businessId);

            //Debug.LogError("ShowNode " + businessId);
            var go = dicRentGameObjects[businessId];
            var nodeView = go.GetComponent<TiktokLevelNodeView>();
            dicLevelNodesUid.Add(go.GetHashCode(), businessId);
            nodeView.onClicked += NodeView_onClicked;
            var data = new PanelData()
            {
                nodeView = nodeView,
                businessId = businessId
            };
            SendEvent<EventNodeShow>(data);
        }

        protected override string GetPrefabUid(LevelsNodesCfgData cfgData)
        {
            return cfgData.PrefabUid;
        }


        public override void HideNode(string businessId)
        {
            var go = dicRentGameObjects[businessId];
            go.GetComponent<TiktokLevelNodeView>().onClicked -= NodeView_onClicked;
            dicLevelNodesUid.Remove(go.GetHashCode());

            base.HideNode(businessId);
        }

        public GameObject GetNode(string businessId)
        {
            return dicRentGameObjects[businessId];
        }

        /// <summary>
        /// 节点被点击
        /// </summary>
        /// <param name="nodeView"></param>
        private void NodeView_onClicked(TiktokLevelNodeView nodeView)
        {
            var nodeUid = dicLevelNodesUid[nodeView.gameObject.GetHashCode()];
            Debug.Log(nodeUid + "  节点被点击了");

            SendEvent<EventLevelNodeClicked>(new PanelData() { nodeView = nodeView, businessId = nodeUid});
        }

        protected override void UpdateNode(LevelNodeDTO updatedNode) { }
    }
}
