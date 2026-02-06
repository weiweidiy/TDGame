using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using Game.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JFramework.Game.View
{
    public class UIPanelCommonReward : UIPanelBase<UIPanelCommonRewardProperties>
    {
        public class UIPanelCommonRewardPanelData : BasePanelData
        {
        }

        [SerializeField] EnhancedScrollerViewAdvanceV2 scroller;
        NormalEnhancedScrollerDelegateV2 scrollerDel;

        protected override void Awake()
        {
            base.Awake();
            scrollerDel = new NormalEnhancedScrollerDelegateV2(scroller, new List<EnhancedDataV2>(), GetUnitViewFactories());
            scroller.Delegate = scrollerDel;
        }

        protected override void OnPanelRefresh(UIPanelCommonRewardProperties properties)
        {
            scrollerDel.Reload(properties.dataList);
            if (properties.dataList.Count > 1)
                scrollerDel.Resize(properties.dataList.Count, EnhancedScrollerDelegateV2.ResizeDirection.Center);
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelCommonRewardPanelData() { panel = this };
        }


        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UIRewardScrollerUnitView.Factory());
            return result;
        }

        //protected override void OnPropertiesSet()
        //{
        //    base.OnPropertiesSet();
        //    //btnClose.onClicked.AddListener(OnBtnCloseClicked);

        //    scrollerDel.Reload(Properties.dataList);
        //    if (Properties.dataList.Count > 1)
        //        scrollerDel.Resize(Properties.dataList.Count, EnhancedScrollerDelegateV2.ResizeDirection.Center);
        //}

        //private void OnBtnCloseClicked()
        //{
        //    SendEvent<EventCloseBtnClicked>(this);
        //}

        //protected override void WhileHiding()
        //{
        //    base.WhileHiding();
        //    //btnClose.onClicked.RemoveListener(OnBtnCloseClicked);

        //}


    }

    public class UIPanelCommonRewardProperties : PanelProperties
    {
        public List<EnhancedDataV2> dataList;
    }
}
