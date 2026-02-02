using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{
    public class UIPanelShop : UIPanelBase<UIPanelShopProperties>
    {
        public class EventCellClicked : JFramework.Event { }

        public class UIPanelLevelListPanelData : BasePanelData
        {

        }

        [SerializeField] EnhancedScrollerViewAdvanceV2 scrollerLevelList;
        NormalEnhancedScrollerDelegateV2 scrollerLevelListDel;

        protected override void Awake()
        {
            base.Awake();
            scrollerLevelListDel = new NormalEnhancedScrollerDelegateV2(scrollerLevelList, new List<EnhancedDataV2>(), GetLevelListUnitViewFactories(), GetLevelListEventHandler());
            scrollerLevelList.Delegate = scrollerLevelListDel;
        }

        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetLevelListUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UILevelListScrollerUnitView.Factory());
            return result;
        }

        private Dictionary<string, Action<string, object>> GetLevelListEventHandler()
        {
            var result = new Dictionary<string, Action<string, object>>();
            result.Add(UILevelListScrollerUnitView.OnLevelUnitClicked, (eventName, eventData) =>
            {
                string levelUid = eventData as string;
                Debug.Log($"Level Unit Clicked: {levelUid}");
                //在这里处理关卡单元点击事件，比如打开关卡详情界面等
                SendEvent<EventCellClicked>(levelUid);
            });
            return result;
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelLevelListPanelData() { panel = this };
        }

        protected override void OnPanelRefresh(UIPanelShopProperties properties)
        {
            scrollerLevelListDel.Reload(Properties.dataLevelList);
        }
    }

    public class UIPanelShopProperties : PanelProperties
    {
        public List<EnhancedDataV2> dataLevelList;
    }
}

