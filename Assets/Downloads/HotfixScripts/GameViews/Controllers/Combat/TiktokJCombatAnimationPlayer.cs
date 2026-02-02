using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game;
using Spine.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Tiktok
{
    public class TiktokJCombatAnimationPlayer : IJCombatAnimationPlayer
    {
        public class UnitData
        {
            public bool isPlayer;
            public string samuraiBusinessId;
            public string soldierBusinessId;
            public int curHp;
            public int maxHp;
            public int attack;
            public int defense;

        }

        public event Action onExitClicked;
        /// <summary>
        /// 有单位释放技能了
        /// </summary>
        public event Action<UnitData> onUnitCast;
        public event Action<UnitData> onUnitHurt;

        [Inject]
        IAssetsLoader assetsLoader;

        [Inject]
        TiktokConfigManager jConfigManager;

        [Inject]
        protected TiktokGameObjectManager gameObjectManager;

        [Inject]
        protected EventManager eventManager;

        [Inject]
        protected LevelsModel levelsModel;

        [Inject]
        protected PlayerModel playerModel;

        TaskCompletionSource<bool> tcs = null;

        /// <summary>
        /// 战斗单位缓存
        /// </summary>
        Dictionary<string, IAnimationPlayer> combatUnits = new Dictionary<string, IAnimationPlayer>();

        /// <summary>
        /// 整个战场view
        /// </summary>
        TiktokCombatView combatView;

        /// <summary>
        /// 战斗日报
        /// </summary>
        TiktokJCombatTurnBasedReportData report;

        /// <summary>
        /// 语言包管理器
        /// </summary>
        ILanguageManager languageManager;

        [Inject]
        public TiktokJCombatAnimationPlayer(ILanguageManager languageManager)
        {
            Debug.Log("TiktokJCombatAnimationPlayer Constructor " + GetHashCode());
            this.languageManager = languageManager;
        }

        /// <summary>
        /// 初始化战斗动画播放
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportData"></param>
        /// <returns></returns>
        public async Task Initialize<T>(JCombatTurnBasedReportData<T> reportData) where T : IJCombatUnitData
        {
            report = reportData as TiktokJCombatTurnBasedReportData;

            this.tcs = tcs == null ? new TaskCompletionSource<bool>() : tcs;

            //创建战斗场景，战斗单位等
            var scenceBusinessId = report.CombatSceneBusinessId;
            var cfgData = jConfigManager.Get<CombatScenesCfgData>(scenceBusinessId);
            var prefabData = jConfigManager.Get<PrefabsCfgData>(cfgData.PrefabUid);
            var goCombat = gameObjectManager.Rent(prefabData.PrefabName);
            goCombat.transform.SetParent(gameObjectManager.GoRoot.transform);
            goCombat.transform.localPosition = Vector3.zero;
            combatView = goCombat.GetComponent<TiktokCombatView>();
            combatView.onMaskClicked += CombatView_onMaskClicked;

            //创建战斗单位
            var playerUid = GetPlayerUid();
            var playerFormation = report.FormationData[playerUid];
            var task1 = InitFormationUnits(playerFormation, combatView,true);

            var levelNodeFormation = GetLevelNodeFormation(report.FormationData, playerUid);
            var task2 = InitFormationUnits(levelNodeFormation, combatView);
            var task3 = combatView.Play("", false);
            var task4 = Task.Delay(1000);

            await Task.WhenAll(task1, task2, task3, task4);
        }



        /// <summary>
        /// 创建战斗单位GameObject
        /// </summary>
        /// <param name="formationList"></param>
        /// <param name="combatView"></param>
        /// <param name="flipX"></param>
        /// <returns></returns>
        async Task InitFormationUnits(List<TiktokJCombatUnitData> formationList, TiktokCombatView combatView, bool flipX = false)
        {

            foreach (var unitData in formationList)
            {
                var uid = unitData.Uid;
                var samuraiBusinessId = unitData.SamuraiBusinessId;
                var soldierBusinessId = unitData.SoldierBusinessId;
                var seat = unitData.Seat;
                var soldierCfgData = jConfigManager.Get<SoldiersCfgData>(soldierBusinessId);
                var soldierPrefabData = jConfigManager.Get<PrefabsCfgData>(soldierCfgData.PrefabUid);
                var goUnit = gameObjectManager.Rent(soldierPrefabData.PrefabName);
                var offset = !flipX ? 9 : 0;
                goUnit.transform.SetParent(combatView.GetSeat(seat + offset));
                goUnit.transform.localPosition = Vector3.zero;
                var animationPlayer = goUnit.GetComponent<IAnimationPlayer>();
                var spineAsset = await assetsLoader.LoadAssetAsync<SkeletonDataAsset>(GetAnimation(soldierBusinessId));
                animationPlayer.SetAnimation(spineAsset, flipX);
                combatUnits.Add(uid, animationPlayer);
            }
        }

        /// <summary>
        /// 返回租借的游戏对象
        /// </summary>
        public void Clear()
        {
            foreach (var animationPlayer in combatUnits.Values)
            {
                gameObjectManager.Return((animationPlayer as MonoBehaviour).gameObject);
            }

            combatView.onMaskClicked -= CombatView_onMaskClicked;
            gameObjectManager.Return(combatView.gameObject);
            combatUnits.Clear();
        }

        #region Get方法
        /// <summary>
        /// 获取玩家战斗单位的数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="playerUid"></param>
        /// <returns></returns>
        List<TiktokJCombatUnitData> GetLevelNodeFormation(Dictionary<string, List<TiktokJCombatUnitData>> data, string playerUid)
        {
            var keys = data.Keys;
            foreach (var key in keys)
            {
                if (key != playerUid)
                    return data[key];
            }
            return null;
        }

        /// <summary>
        /// 获取兵种的动画
        /// </summary>
        /// <param name="soldierBusinessId"></param>
        /// <returns></returns>
        private string GetAnimation(string soldierBusinessId)
        {
            return jConfigManager.GetSoldierAnimation(soldierBusinessId)[0];
        }

        /// <summary>
        /// 获取action的业务ID
        /// </summary>
        /// <param name="actionUid"></param>
        /// <returns></returns>
        string GetActionBusinessId(string actionUid)
        {
            //从report中获取formation
            foreach (var formation in report.FormationData.Values)
            {
                foreach (var unit in formation)
                {
                    var actions = unit.Actions;
                    foreach (var action in actions)
                    {
                        var uid = action.Key;
                        var businessId = action.Value;
                        if (actionUid == uid)
                        {
                            return businessId;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 获取武士的业务id
        /// </summary>
        /// <param name="unitUid"></param>
        /// <returns></returns>
        string GetSamuraitBusinessId(string unitUid)
        {
            foreach (var formation in report.FormationData.Values)
            {
                foreach (var unit in formation)
                {
                    if (unit.Uid.Equals(unitUid))
                        return unit.SamuraiBusinessId;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取兵种的业务id
        /// </summary>
        /// <param name="unitUid"></param>
        /// <returns></returns>
        string GetSoldierBusinessId(string unitUid)
        {
            foreach (var formation in report.FormationData.Values)
            {
                foreach (var unit in formation)
                {
                    if (unit.Uid.Equals(unitUid))
                        return unit.SoldierBusinessId;
                }
            }
            return null;
        }

        /// <summary>
        /// 是否是玩家单位
        /// </summary>
        /// <param name="unitUid"></param>
        /// <param name="playerUid"></param>
        /// <returns></returns>
        bool IsPlayerUnit(string unitUid, string playerUid)
        {
            var playerFormation = report.FormationData[playerUid];
            //检查unitUid是否存在于playerFormation中
            foreach (var unit in playerFormation)
            {
                if (unit.Uid.Equals(unitUid))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取玩家uid
        /// </summary>
        /// <returns></returns>
        string GetPlayerUid()
        {
            return playerModel.GetPlayerUid();
        }

        #endregion

        #region UI交互影响事件
        /// <summary>
        /// 退出按钮被点击了
        /// </summary>
        /// <param name="obj"></param>
        private void CombatView_onMaskClicked(TiktokCombatView obj)
        {
            onExitClicked?.Invoke();
        }
        #endregion

        #region 播放动画
        /// <summary>
        /// 播放回合开始
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public Task PlayTurnStart(int frame)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 播放一个动画事件
        /// </summary>
        /// <param name="actionEvent"></param>
        /// <returns></returns>
        public async Task PlayAcion(JCombatTurnBasedEvent actionEvent)
        {
            var curFrame = actionEvent.CurFrame;
            var actions = actionEvent.ActionEvents;
            //从actions中获取行动开始类型的所有actions
            var actionStartEvents = actions.Where(a =>
            {
                var actionUid = a.ActionUid;
                var actionBusinessId = GetActionBusinessId(actionUid);
                return jConfigManager.GetActionTiming(actionBusinessId) == ActionTiming.ActionStart;
            }).ToList();

            //播放技能动作和特效
            foreach (var action in actionStartEvents)
            {
                var casterUid = action.CasterUid;
                var casterCurHp = actionEvent.CurHp;
                var casterMaxHp = actionEvent.MaxHp;
                var actionUid = action.ActionUid;
                var actionBusinessId = GetActionBusinessId(actionUid);
                var actionName = languageManager.GetText(jConfigManager.GetLanguageBusinessIdByActionBusiness(actionBusinessId));
                var needShowName = jConfigManager.GetActionNeedShowName(actionBusinessId);
                var actionAnimationName = jConfigManager.GetActionUnitAnimationName(actionBusinessId);
                var actionHitAnimationName = jConfigManager.GetActionHitAnimationName(actionBusinessId);
                if (needShowName)
                    await PlayActionName(casterUid, actionName);

                //播放释放者的动作，并通知外部有单位释放技能了
                var casterUnitData = CreateUnitData(casterUid, casterCurHp, casterMaxHp);
                onUnitCast?.Invoke(casterUnitData);

                await combatUnits[casterUid].Play(actionAnimationName, false);

                //播放伤害效果
                if (action.ActionEffect.ContainsKey(CombatEventActionType.Damage))
                {
                    var primaryTargetUid = "";
                    int primaryTargetHp = -1;
                    int primaryTargetMaxHp = -1;
                    var tasks = new List<Task>();
                    foreach (var info in action.ActionEffect[CombatEventActionType.Damage])
                    {
                        if (string.IsNullOrEmpty(primaryTargetUid))
                            primaryTargetUid = info.TargetUid;

                        if(primaryTargetHp == -1)
                            primaryTargetHp = info.TargetHp;

                        if (primaryTargetMaxHp == -1)
                            primaryTargetMaxHp = info.TargetMaxHp;


                        var targetUid = info.TargetUid;
                        var damage = info.Value;
                        var targetHp = info.TargetHp;
                        var targetMaxHp = info.TargetMaxHp;

                        //播放伤害数值文本
                        tasks.Add(PlayDamageText(targetUid, damage));

                        //播放命中效果
                        tasks.Add(PlayActionHitAnimation(targetUid, actionHitAnimationName));

                        //播放目标受伤动画（HP变化）
                        tasks.Add(PlayUnitHurtAnimation(targetUid, targetHp / (float)targetMaxHp));

                        //播放被命中时候触发的技能名字
                        tasks.Add(PlayHittedActionName(targetUid, actions));

                    }

                    //播放主要目标受伤动画，并通知外部有单位受伤了
                    var targetUnitData = CreateUnitData(primaryTargetUid, primaryTargetHp, primaryTargetMaxHp);
                    onUnitHurt?.Invoke(targetUnitData);

                    //等待tasks全部完成
                    await Task.WhenAll(tasks);
                }
            }
        }

        UnitData CreateUnitData(string uid, int curHp, int maxHp)
        {
            var samuraiBusinessId = GetSamuraitBusinessId(uid);
            var soldierBusinessId = GetSoldierBusinessId(uid);
            var unitData = new UnitData();
            unitData.samuraiBusinessId = samuraiBusinessId;
            unitData.isPlayer = IsPlayerUnit(uid, GetPlayerUid());
            unitData.curHp = curHp;
            unitData.maxHp = maxHp;
            unitData.soldierBusinessId = soldierBusinessId;
            return unitData;
        }

        /// <summary>
        /// 播放单位收到攻击的动画（hp变化）
        /// </summary>
        /// <param name="targetUid"></param>
        /// <param name="v"></param>
        private Task PlayUnitHurtAnimation(string targetUid, float v)
        {
            return (combatUnits[targetUid] as CombatMultiUnitSpinePlayer).PlayHurt(v);
        }

        /// <summary>
        /// 播放技能命中效果
        /// </summary>
        /// <param name="targetUid"></param>
        async Task PlayActionHitAnimation(string targetUid, string prefabName)
        {
            var goHit = gameObjectManager.Rent(prefabName);
            goHit.transform.SetParent((combatUnits[targetUid] as MonoBehaviour).transform);
            goHit.transform.localPosition = Vector3.zero;
            var animationPlayer = goHit.GetComponent<IAnimationPlayer>();
            await animationPlayer.Play("", false);
            gameObjectManager.Return(goHit);
        }

        /// <summary>
        /// 播放收到攻击时候触发的技能名字
        /// </summary>
        /// <param name="targetUid"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        async Task PlayHittedActionName(string targetUid, List<ActionEvent> actions)
        {
            //从actions中获取释放者是targetUid，且timing是 ActionTiming.Hurt 的所有actions
            var actionHurtEvents = actions.Where(a =>
            {
                var actionUid = a.ActionUid;
                var actionBusinessId = GetActionBusinessId(actionUid);
                return jConfigManager.GetActionTiming(actionBusinessId) == ActionTiming.Hurt && a.CasterUid == targetUid;
            }).ToList();


            foreach (var action in actionHurtEvents)
            {
                var casterUid = action.CasterUid;
                var actionUid = action.ActionUid;
                var actionBusinessId = GetActionBusinessId(actionUid);
                var actionName = languageManager.GetText(jConfigManager.GetLanguageBusinessIdByActionBusiness(actionBusinessId));
                var needShowName = jConfigManager.GetActionNeedShowName(actionBusinessId);
                if (needShowName)
                    await PlayActionName(casterUid, actionName);
            }
        }

        /// <summary>
        /// 播放伤害的数值文本
        /// </summary>
        /// <param name="targetUid"></param>
        /// <param name="damage"></param>
        /// <returns></returns>
        async Task PlayDamageText(string targetUid, int damage)
        {
            if (combatUnits.ContainsKey(targetUid))
            {
                var txtDamage = gameObjectManager.Rent(jConfigManager.GetCombatDamageTextPrefab());
                txtDamage.transform.SetParent((combatUnits[targetUid] as MonoBehaviour).transform);
                txtDamage.transform.localPosition = Vector3.zero + new Vector3(0, 1.5f, 0);
                txtDamage.GetComponent<TextView>().SetText("-" + damage.ToString());
                var animationPlayer = txtDamage.GetComponent<IAnimationPlayer>();
                await animationPlayer.Play("", false);
                gameObjectManager.Return(txtDamage);
            }
            else
            {
                Debug.LogWarning($"Target {targetUid} not found in combat units.");
            }
        }

        /// <summary>
        /// 播放技能名字
        /// </summary>
        /// <param name="casterUid"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        async Task PlayActionName(string casterUid, string actionName)
        {
            if (combatUnits.ContainsKey(casterUid))
            {
                var txtDamage = gameObjectManager.Rent(jConfigManager.GetCombatActionNameTextPrefab());
                txtDamage.transform.SetParent((combatUnits[casterUid] as MonoBehaviour).transform);
                txtDamage.transform.localPosition = Vector3.zero + new Vector3(0, 1.5f, 0);
                txtDamage.GetComponent<TextView>().SetText(actionName);
                var animationPlayer = txtDamage.GetComponent<IAnimationPlayer>();
                await animationPlayer.Play("", false);
                gameObjectManager.Return(txtDamage);
            }
            else
            {
                Debug.LogWarning($"Target {casterUid} not found in combat units.");
            }
        }
        #endregion
    }
}

