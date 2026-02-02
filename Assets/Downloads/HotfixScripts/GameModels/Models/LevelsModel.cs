using Adic;
using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class LevelsModel : BaseDictionaryModel<LevelNodeDTO> //  BaseModel<LevelData>
    {
        public class EventLevelNodeUpdate : Event { }

        TiktokConfigManager jConfigManager;

        [Inject]
        public LevelsModel(EventManager eventManager, TiktokConfigManager jConfigManager, Func<LevelNodeDTO, string> keySelector) : base(keySelector,eventManager)
        {
            this.jConfigManager = jConfigManager;
        }

        public void Initialize(List<LevelNodeDTO> unlockedNodes)
        {
            AddRange(unlockedNodes);

            if(unlockedNodes.Count == 0)
            {
                //如果没有解锁的节点，则添加第一个默认节点
                var firstNodeUid = jConfigManager.GetDefaultFirstNode();
                if (firstNodeUid != null)
                {
                    var firstNode = new LevelNodeDTO
                    {
                        BusinessId = firstNodeUid,
                        Process = 0
                    };
                    Add(firstNode);
                }
            }
            else
                //更新并添加后置节点
                AddNextNodes(unlockedNodes); 
        }


        List<LevelNodeDTO> AddNextNodes(List<LevelNodeDTO> targetNodes)
        {
            var result = new List<LevelNodeDTO>();

            foreach (var node in targetNodes)
            {
                var nextNodesUid = jConfigManager.GetNextLevelNode(node.BusinessId.ToString());
                foreach (var nextNodeUid in nextNodesUid)
                {
                    if (nextNodeUid == "0" || (node.Process > 1 && Get(nextNodeUid) != null))
                        continue;

                    if (Get(nextNodeUid) == null && node.Process > 0)
                    {
                        var nextNode = new LevelNodeDTO
                        {
                            BusinessId = nextNodeUid,
                            Process = 0
                        };
                        Add(nextNode);
                        result.Add(nextNode);
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// 获取所有指定关卡的已经解锁的所有节点数据
        /// </summary>
        /// <param name="levelUid"></param>
        /// <returns></returns>
        public List<LevelNodeDTO> GetUnlockedLevelNodes(string levelUid)
        {
            var result = new List<LevelNodeDTO>();

            foreach (var vo in GetAll())
            {
                var cfgData = jConfigManager.Get<LevelsNodesCfgData>(vo.BusinessId.ToString());
                if (cfgData.LevelUid == levelUid)
                {
                    result.Add(vo);
                }
            }

            return result;
        }

        /// <summary>
        /// 指定关卡是否解锁了
        /// </summary>
        /// <param name="levelUid"></param>
        /// <returns></returns>
        public bool IsLevelUnlocked(string levelUid)
        {
            var nodes = GetUnlockedLevelNodes(levelUid);
            return nodes.Count > 0;
        }

        /// <summary>
        /// <!-更新节点数据--->
        /// </summary>
        /// <param name="updatedNode"></param>
        public void UpdateNode(LevelNodeDTO updatedNode)
        {
            UpdateData(updatedNode);

            var nextNodes = AddNextNodes(new List<LevelNodeDTO> { updatedNode });
            var needUpdateNodes = new List<LevelNodeDTO> { updatedNode };
            needUpdateNodes.AddRange(nextNodes);

            foreach(var node in needUpdateNodes)
                UnityEngine.Debug.Log(" node uid " + node.BusinessId + " process " + node.Process);

            SendEvent<EventLevelNodeUpdate>(needUpdateNodes);
        }

        public int GetNodeProcess(string levelNodeBusinessId)
        {
            if (string.IsNullOrEmpty(levelNodeBusinessId))
                return 0;
            var node = Get(levelNodeBusinessId);
            if (node != null)
                return node.Process;
            return 0;
        }

        
    }

}
