using Adic;
using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using System;
using System.Collections.Generic;
using Tiktok;
using UnityEngine;
using UnityEngine.UI;

namespace JFramework.Game.View
{ 

    public class UIPanelSamuraisList : UIPanelBase<UIPanelSamuraisListProperties>
    {
        public class UIPanelSamuraisListPanelData : BasePanelData
        {
            
        }

        [SerializeField] EnhancedScrollerViewAdvanceV2 scroller;
        NormalEnhancedScrollerDelegateV2 scrollerDel;

        [SerializeField] BaseSingleTextView txtCount;
        [SerializeField] BaseSingleTextView txtTitle;

        protected override void Awake()
        {
            base.Awake();

            scrollerDel = new NormalEnhancedScrollerDelegateV2(scroller, new List<EnhancedDataV2>(), GetUnitViewFactories());
            scroller.Delegate = scrollerDel;
        }

        protected override void OnPanelRefresh(UIPanelSamuraisListProperties properties)
        {
            scrollerDel.Reload(properties.dataList);
            txtCount.Refresh(properties.count);
            txtTitle.Refresh(properties.title);
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelSamuraisListPanelData() { panel = this };
        }



        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UISamuraiScrollerUnitView.Factory());
            return result;
        }

       
    }


    public class UIPanelSamuraisListProperties : PanelProperties
    {
        public List<EnhancedDataV2> dataList;
        public string count; //当前武将数量
        public string title; //标题
    }
}
