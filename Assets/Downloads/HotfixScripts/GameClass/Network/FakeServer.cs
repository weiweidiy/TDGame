//using Adic;
//using Cysharp.Threading.Tasks;
//using JFramework;
//using JFramework.Game;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using UnityEngine;



//namespace Tiktok
//{

//    public class FakeServer
//    {
//        INetworkMessageProcessStrate processStrate;

//        LevelsManager levelsManager;

//        IJConfigManager tiktokConfigManager;

//        IGameDataStore jDataStore;

//        FakeNotifier clientNotifier;

//        [Inject]
//        public FakeServer(IGameDataStore jDataStore, IJConfigManager configManager, LevelsManager levelManager, [Inject("Server")] INetworkMessageProcessStrate processStrate)
//        {
//            this.processStrate = processStrate;
//            this.tiktokConfigManager = configManager;
//            this.levelsManager = levelManager;
//            this.jDataStore = jDataStore;
//        }

//        [Inject]
//        public void Initialize(FakeNotifier clientNotifier)
//        {
//            this.clientNotifier = clientNotifier;
//        }



//        public async Task<byte[]> OnRevieveData(byte[] data)
//        {
//            //处理收到的消息
//            var message = processStrate.ProcessComingMessage(data);
//            switch (message.TypeId)
//            {
//                case (int)ProtocolType.LoginReq:
//                    return await OnLogin(message);

//                case (int)ProtocolType.FightReq:
//                    return await OnFight(message);
//                default:
//                    throw new Exception("没有实现协议 " + message.TypeId);

//            }
//        }



//        async Task<byte[]> OnLogin(IJNetMessage message)
//        {
//            var msg = message as LoginReq;
//            var hasAccount = await jDataStore.ExistsAsync(nameof(AccountData));
//            if (!hasAccount)
//            {
//                var accountData = new AccountData();
//                accountData.AccountId = "test";
//                await jDataStore.SaveAsync(nameof(AccountData), accountData);
//            }

//            //初始化管理器
//            levelsManager.Initialize(await GetLevelDataFromDataBase(""));


//            //返回登录成功
//            var response = new LoginRes()
//            {
//                Code = 0,
//                Uid = message.Uid,
//                LevelData = levelsManager.Data
//            };
//            return processStrate.ProcessOutMessage(response);
//        }


//        private async Task<byte[]> OnFight(IJNetMessage message)
//        {
//            var fightReq = message as FightReq;
//            var nodeUid = fightReq.LevelNodeUid;


//            //检查是否解锁


//            //to do: 模拟战斗
//            var result = true;


//            //根据战斗结果，解锁后续节点或关卡
//            var nodeCfgData = tiktokConfigManager.Get<LevelsNodesCfgData>(nodeUid);
//            var nextNodeUid = nodeCfgData.NextUid;

//            if (result)
//            {
//                //解锁
//                var unlocked = await levelsManager.UnlockNodes(nextNodeUid);
//                //通知解锁
//                if (unlocked.Count > 0)
//                    NotifyUnlock(unlocked);

//            }


//            var response = new FightRes()
//            {
//                Code = 0,
//                Uid = message.Uid,
//            };
//            return processStrate.ProcessOutMessage(response);
//        }

//        private async void NotifyUnlock(List<string> nextNodeUid)
//        {
//            await UniTask.Yield();
//            var ntf = new LevelNodeUnlockedNtf();
//            ntf.Uid = Guid.NewGuid().ToString();
//            ntf.LevelNodeUid = nextNodeUid;
//            var msgNtf = processStrate.ProcessOutMessage(ntf);
//            clientNotifier.Notify(msgNtf);
//        }

//        async Task<LevelData> GetLevelDataFromDataBase(string accountId)
//        {
//            //从存档里获取记录，如果没有就创建个默认的
//            var levelData = await jDataStore.GetAsync<LevelData>(nameof(LevelData));

//            if (levelData != null)
//                return levelData;

//            //没有数据，要创建默认数据
//            levelData = new LevelData();
//            //levelData.CurLevelUid = "1";

//            //var dicLevelsData = new Dictionary<string, LevelNodeVO>();
//            var dicLevelsData = new List<LevelNodeVO>();
//            levelData.UnlockedLevelNodesData = dicLevelsData;
//            var allNodes = tiktokConfigManager.GetAll<LevelsNodesCfgData>(); //这里还没有预加载呢


//            foreach (var levelNode in allNodes)
//            {
//                var vo = new LevelNodeVO();
//                vo.Uid = levelNode.Uid;
//                vo.state = levelNode.Uid == "1" ? LevelState.Unlocked : LevelState.Locked;
//                dicLevelsData.Add(vo);

//            }

//            await jDataStore.SaveAsync(nameof(LevelData), levelData);
//            return levelData;
//        }
//    }
//}

