using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using Game.Common;
using System;
using System.Collections.Generic;
using Tiktok;
using UnityEngine;
using UnityEngine.UI;


namespace JFramework.Game.View
{

    public class UIPanelLevelNodeDetail : UIPanelBase<UIPanelLevelNodeEntranceProperties>
    {
        #region Events
        ///// <summary>
        ///// 关闭按钮点击事件
        ///// </summary>
        //public class EventCloseBtnClicked : Event { }

        /// <summary>
        /// 布阵武将被点击
        /// </summary>
        public class EventDeploySamuraiClicked : Event { }
        #endregion

        public class UIPanelLevelNodeDetailPanelData : BasePanelData
        {
            public string levelNodeBusinessId;
        }

        [SerializeField] EnhancedScrollerViewAdvanceV2 scrollerDeploy;
        NormalEnhancedScrollerDelegateV2 scrollerDeployDel;
        [SerializeField] EnhancedScrollerViewAdvanceV2 scrollerAchievements;
        NormalEnhancedScrollerDelegateV2 scrollerAchievementsDel;
        [SerializeField] SamuraiDetailInfoView samuraiDetailInfoView;


        protected override void Awake()
        {
            base.Awake();

            scrollerDeployDel = new NormalEnhancedScrollerDelegateV2(scrollerDeploy, new List<EnhancedDataV2>(), GetLevelNodeFormationUnitViewFactories(), GetCustomeEventHandlers());
            scrollerDeploy.Delegate = scrollerDeployDel;
            scrollerAchievementsDel = new NormalEnhancedScrollerDelegateV2(scrollerAchievements, new List<EnhancedDataV2>(), GetLevelNodeAchievementUnitViewFactories());
            scrollerAchievements.Delegate = scrollerAchievementsDel;
        }

        protected override void OnPanelRefresh(UIPanelLevelNodeEntranceProperties properties)
        {
            scrollerDeployDel.Reload(Properties.dataDeployList);
            scrollerAchievementsDel.Reload(Properties.dataAchievementList);
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelLevelNodeDetailPanelData() { panel = this, levelNodeBusinessId = Properties.levelNodeBusinessId };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            Properties.onRefreshSamuraiInfo += OnRefreshSamuraiInfo;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            Properties.onRefreshSamuraiInfo += OnRefreshSamuraiInfo;
        }

        private void OnRefreshSamuraiInfo(SamuraiDetailInfo info)
        {
            samuraiDetailInfoView?.Refresh(info);
        }


        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetLevelNodeFormationUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UIDeployScrollerUnitView.Factory());
            return result;
        }

        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetLevelNodeAchievementUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UIAchievementScrollerUnitView.Factory());
            return result;
        }

        private Dictionary<string, Action<string, object>> GetCustomeEventHandlers()
        {
            var result = new Dictionary<string, Action<string, object>>();

            result.Add(UIDeployScrollerUnitView.OnInit, OnInit);
            result.Add(UIDeployScrollerUnitView.OnRefresh, OnRefresh);

            return result;
        }

        /// <summary>
        /// 阵型上的单位视图被初始化
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="initData"></param>
        private void OnInit(string eventName, object initData)
        {
            var customInitData = initData as UIDeployScrollerUnitView.CustomInitData;
            var clickHandler = customInitData.imgHead.transform.GetComponent<UIClickHandler>();
            if (clickHandler == null)
            {
                clickHandler = customInitData.imgHead.transform.gameObject.AddComponent<UIClickHandler>();
            }
            clickHandler.onClicked += OnLevelNodeDeployUnitClicked;
        }

        /// <summary>
        /// 阵型上的单位数据被刷新
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="arg"></param>
        private void OnRefresh(string eventName, object arg)
        {
            var refreshData = arg as UIDeployScrollerUnitView.CustomRefreshData;
            var clickHandler = refreshData.imgHead.GetComponent<UIClickHandler>();
            clickHandler.TargetArg = refreshData.unitData;
        }

        /// <summary>
        /// 阵型上的单位被点击
        /// </summary>
        /// <param name="target"></param>
        void OnLevelNodeDeployUnitClicked(object target)
        {
            var unitData = target as UIDeployScrollerUnitView.UnitData;
            Debug.Log($"click unit {unitData.businessId}");
            SendEvent<EventDeploySamuraiClicked>(unitData.businessId);
        }


    }

    public class UIPanelLevelNodeEntranceProperties : PanelProperties
    {
        public event Action<SamuraiDetailInfo> onRefreshSamuraiInfo;
        public string levelNodeBusinessId;
        public List<EnhancedDataV2> dataDeployList;
        public List<EnhancedDataV2> dataAchievementList;

        public void RefreshSamuraiInfo(SamuraiDetailInfo samuraiDetailInfo)
        {
            onRefreshSamuraiInfo?.Invoke(samuraiDetailInfo);
        }
    }
}
