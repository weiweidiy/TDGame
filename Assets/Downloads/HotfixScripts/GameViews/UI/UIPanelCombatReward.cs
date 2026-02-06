using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using Game.Common;
using System.Collections.Generic;
using UnityEngine;

namespace JFramework.Game.View
{
    /// <summary>
    /// 战斗结束的奖励面板，可能同时有胜利奖励和成就奖励
    /// </summary>
    public class UIPanelCombatReward : UIPanelBase<UIPanelCombatRewardProperties>
    {
        public class UIPanelCombatRewardPanelData : BasePanelData
        {
        }


        [SerializeField] EnhancedScrollerViewAdvanceV2 winScroller;
        NormalEnhancedScrollerDelegateV2 winScrollerDel;

        [SerializeField] EnhancedScrollerViewAdvanceV2 achievementScroller;
        NormalEnhancedScrollerDelegateV2 achievementScrollerDel;
        protected override void Awake()
        {
            base.Awake();
            //胜利奖励列表
            winScrollerDel = new NormalEnhancedScrollerDelegateV2(winScroller, new List<EnhancedDataV2>(), GetUnitViewFactories());
            winScroller.Delegate = winScrollerDel;
            //成就奖励列表
            achievementScrollerDel = new NormalEnhancedScrollerDelegateV2(achievementScroller, new List<EnhancedDataV2>(), GetUnitViewFactories());
            achievementScroller.Delegate = achievementScrollerDel;

        }

        /// <summary>
        /// 获取单元视图工厂字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UIRewardScrollerUnitView.Factory());
            return result;
        }

        /// <summary>
        /// 面板刷新
        /// </summary>
        /// <param name="properties"></param>
        protected override void OnPanelRefresh(UIPanelCombatRewardProperties properties)
        {
            winScrollerDel.Reload(Properties.winDataList);
            if (Properties.winDataList.Count > 1)
                winScrollerDel.Resize(Properties.winDataList.Count, EnhancedScrollerDelegateV2.ResizeDirection.Center);

            //如果有成就奖励，则显示成就奖励列表
            if (Properties.achievementDataList != null && Properties.achievementDataList.Count > 0)
            {
                achievementScrollerDel.Reload(Properties.achievementDataList);
                if (Properties.achievementDataList.Count > 1)
                    achievementScrollerDel.Resize(Properties.achievementDataList.Count, EnhancedScrollerDelegateV2.ResizeDirection.Center);
            }
            else
            {
                achievementScroller.transform.parent.gameObject.SetActive(false);
            }
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelCombatRewardPanelData() { panel = this };
        }
    }


    public class UIPanelCombatRewardProperties : PanelProperties
    {
        public List<EnhancedDataV2> winDataList;
        public List<EnhancedDataV2> achievementDataList;
    }
}
//protected override void OnPropertiesSet()
//{
//    base.OnPropertiesSet();
//    btnClose.onClicked.AddListener(OnBtnCloseClicked);



//}


//protected override void WhileHiding()
//{
//    base.WhileHiding();
//    btnClose.onClicked.RemoveListener(OnBtnCloseClicked);
//}

//private void OnBtnCloseClicked()
//{
//    SendEvent<EventCloseBtnClicked>(this);
//}