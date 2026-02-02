using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;

using UnityEngine;



namespace Tiktok
{
    public class UICombatUnitBarController : ViewController
    {
        [Inject]
        TiktokConfigManager tiktokConfigManager;

        [Inject]
        ILanguageManager languageManager;

        [Inject]
        protected TiktokSpritesManager spritesManager;

        UIPanelCombatUnitBarProperties properties;

        public UICombatUnitBarController(EventManager eventManager) : base(eventManager)
        {
        }

        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<TiktokCombatPlayer.EventUnitCast>(OnUnitCast);
            eventManager.AddListener<TiktokCombatPlayer.EventUnitHurt>(OnUnitHurt);

            ShowPanel();
        }

        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<TiktokCombatPlayer.EventUnitCast>(OnUnitCast);
            eventManager.AddListener<TiktokCombatPlayer.EventUnitHurt>(OnUnitHurt);
        }

        protected override void DoOpen(Open e)
        {
            
        }


        public void ShowPanel()
        {
            properties = new UIPanelCombatUnitBarProperties()
            {
                leftUnitInfo = null,
                rightUnitInfo = null
            };
            uiManager.ShowPanel(nameof(UIPanelCombatUnitBar), properties);
        }

        private void OnUnitCast(TiktokCombatPlayer.EventUnitCast e)
        {
            var data = e.Body as TiktokJCombatAnimationPlayer.UnitData;
            RefreshDetailInfo(data);
        }

        private void OnUnitHurt(TiktokCombatPlayer.EventUnitHurt e)
        {
            var data = e.Body as TiktokJCombatAnimationPlayer.UnitData;
            RefreshDetailInfo(data);
        }

        void RefreshDetailInfo(TiktokJCombatAnimationPlayer.UnitData data)
        {
            var isPlayer = data.isPlayer;
            var samuraiBusinessId = data.samuraiBusinessId;
            var soldierBusinessId = data.soldierBusinessId;
            if (properties != null)
            {
                var info = new CombatUnitDetailInfo()
                {
                    name = languageManager.GetText(tiktokConfigManager.GetSamuraiNameLid(samuraiBusinessId)),
                    headIcon = spritesManager.GetSprite(tiktokConfigManager.GetSamuraiHeadIconBusinessId(samuraiBusinessId)),
                    hp = data.curHp,
                    maxHp = data.maxHp,
                    soldierName = languageManager.GetText(tiktokConfigManager.GetSoldierNameLid(soldierBusinessId)),
                };

                properties.leftUnitInfo = isPlayer ? info : properties.leftUnitInfo;
                properties.rightUnitInfo = isPlayer ? properties.rightUnitInfo : info;
                properties.RefreshDetailInfo(/*properties.leftUnitInfo, properties.rightUnitInfo*/);
            }


        }


    }
}
