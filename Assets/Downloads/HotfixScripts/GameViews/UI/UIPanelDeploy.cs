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
    public class UIPanelDeploy : UIPanelBase<UIPanelDeployProperties>
    {
        public class EventSamuraiDroped : Event { }
        public class EventRetreatUnit : Event { }
        public class EventFormationClicked : Event { }
        public class EventSamuraiClicked : Event { }

        public class UIPanelDeployPanelData : BasePanelData
        {
            
        }


        //[SerializeField] AdvancedButton btnClose;

        [SerializeField] EnhancedScrollerViewAdvanceV2 scrollerDeploy;
        NormalEnhancedScrollerDelegateV2 scrollerDeployDel;

        [SerializeField] EnhancedScrollerViewAdvanceV2 scrollerSamurai;
        NormalEnhancedScrollerDelegateV2 scrollerSamuraiDel;

        [SerializeField] EnhancedScrollerViewAdvanceV2 scrollerFormation;
        NormalEnhancedScrollerDelegateV2 scrollerFormationDel;

        /// <summary>
        /// 武将详情面板
        /// </summary>
        [SerializeField] SamuraiDetailInfoView samuraiDetailInfoView;


        [SerializeField] GameObject[] goRetreats;

        [SerializeField] GameObject[] goGuideTargets;


        protected override void Awake()
        {
            base.Awake();

            scrollerDeployDel = new NormalEnhancedScrollerDelegateV2(scrollerDeploy, new List<EnhancedDataV2>(), GetDeployUnitViewFactories(), GetDeployEventHandler());
            scrollerDeploy.Delegate = scrollerDeployDel;

            scrollerSamuraiDel = new NormalEnhancedScrollerDelegateV2(scrollerSamurai, new List<EnhancedDataV2>(), GetSamuraiUnitViewFactories(), GetSamuraiEventHandler());
            scrollerSamurai.Delegate = scrollerSamuraiDel;

            scrollerFormationDel = new NormalEnhancedScrollerDelegateV2(scrollerFormation, new List<EnhancedDataV2>(), GetFormationUnitViewFactories(), GetFormationEventHandler());
            scrollerFormation.Delegate = scrollerFormationDel;

            foreach (var go in goRetreats)
            {
                var dropHandler = go.GetComponent<DeploySamuraiRetreatHandler>();
                if (dropHandler == null)
                {
                    dropHandler = go.AddComponent<DeploySamuraiRetreatHandler>();
                }
                dropHandler.onDrop += OnRetreat;
                dropHandler.RangeScale = 1f;
            }
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();

            Properties.onRefreshDeploy += RefreshDeployList;
            Properties.onRefreshFormation += RefreshFormationList;
            Properties.onRefreshSamurai += RefreshSamuraiDetailInfo;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();

            Properties.onRefreshDeploy -= RefreshDeployList;
            Properties.onRefreshFormation -= RefreshFormationList;
            Properties.onRefreshSamurai -= RefreshSamuraiDetailInfo;
        }

        protected override void OnPanelRefresh(UIPanelDeployProperties properties)
        {
            scrollerDeployDel.Reload(Properties.dataDeployList);
            scrollerSamuraiDel.Reload(Properties.dataSamuraiList);
            scrollerFormationDel.Reload(Properties.dataFormationList);
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelDeployPanelData() { panel = this };
        }

        public GameObject GetGuideTarget(int index)
        {
            return goGuideTargets[index];
        }

        public GameObject GetCloseGameObject() => btnClose.gameObject;

        /// <summary>
        /// 获取布阵事件处理器
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Action<string, object>> GetDeployEventHandler()
        {
            var result = new Dictionary<string, Action<string, object>>();
            result.Add(UIDeployDragableScrollerUnitView.OnDrop, OnDrop);
            result.Add(UIDeployDragableScrollerUnitView.OnClick, OnDeployUnitClick);
            return result;
        }

        /// <summary>
        /// 武将列表事件处理器
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Dictionary<string, Action<string, object>> GetSamuraiEventHandler()
        {
            var result = new Dictionary<string, Action<string, object>>();
            result.Add(UISamuraiScrollerUnitView.OnInit, OnDeploySamuraiUnitInit);
            result.Add(UISamuraiScrollerUnitView.OnRefresh, OnDeploySamuraiUnitRefresh);
            //result.Add(UISamuraiScrollerUnitView.OnClick, OnDeploySamuraiUnitClick);
            return result;
        }

        /// <summary>
        /// unit初始化时调用：需要添加拖拽组件
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void OnDeploySamuraiUnitInit(string arg1, object arg2)
        {
            var data = arg2 as UISamuraiScrollerUnitView.CustomInitData;
            var headIcon = data.headIcon;
            var dragHandler = headIcon.GetComponent<SamuraiIconDragHandler>();
            if (dragHandler == null)
            {
                dragHandler = headIcon.gameObject.AddComponent<SamuraiIconDragHandler>();
            }
            dragHandler.iconImage = headIcon;
            dragHandler.parent = headIcon.transform.parent.parent.parent.parent.parent.parent; // 设置副本显示在最顶层
            dragHandler.onClicked += DragHandler_onClick;
        }

        /// <summary>
        /// Unit刷新时调用：需要更新拖拽组件的数据
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void OnDeploySamuraiUnitRefresh(string arg1, object arg2)
        {
            var data = arg2 as UISamuraiScrollerUnitView.CustomRefreshData;
            var headIcon = data.headIcon;
            var dragHandler = headIcon.GetComponent<SamuraiIconDragHandler>();
            dragHandler.TargetArg = new UIDeployDragableScrollerUnitView.DropData() { samuraiId = data.samuraiId };

        }

        /// <summary>
        /// 被点击了
        /// </summary>
        /// <param name="target"></param>
        private void DragHandler_onClick(object target)
        {
            var data = target as UIDeployDragableScrollerUnitView.DropData;
            SendEvent<EventSamuraiClicked>(data.samuraiId);
        }

        /// <summary>
        /// 获取阵型事件处理器
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Action<string, object>> GetFormationEventHandler()
        {
            var result = new Dictionary<string, Action<string, object>>();
            result.Add(UIFormationScrollerUnitView.EventFormationClick, OnFormationClicked);
            return result;
        }

        /// <summary>
        /// 阵型被点击了
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="arg"></param>
        private void OnFormationClicked(string eventName, object arg)
        {
            var data = arg as UIFormationScrollerUnitView.UnitData;
            Debug.Log($"OnFormationClicked formationId: {data.name} ");
            SendEvent<EventFormationClicked>(data.businessId);
        }

        /// <summary>
        /// 有武将被拖拽到布阵点上
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="arg"></param>
        private void OnDrop(string eventName, object arg)
        {
            var data = arg as UIDeployDragableScrollerUnitView.DropData;
            SendEvent<EventSamuraiDroped>(data);
        }


        /// <summary>
        /// 点击了阵上武将
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="uiPanelDeployUnitViewUnitData"></param>
        private void OnDeployUnitClick(string eventName, object uiPanelDeployUnitViewUnitData)
        {
            var data = uiPanelDeployUnitViewUnitData as UIDeployDragableScrollerUnitView.UnitData;
            SendEvent<EventSamuraiClicked>(data.dto.SamuraiId);
        }

        /// <summary>
        /// 有武将被拖拽到撤退区域
        /// </summary>
        /// <param name="arg"></param>
        private void OnRetreat(object arg)
        {
            var data = arg as UIDeployDragableScrollerUnitView.DropData;

            if (data.samuraiId > 0)
                SendEvent<EventRetreatUnit>(data);
        }


        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetDeployUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UIDeployDragableScrollerUnitView.Factory());
            return result;
        }

        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetSamuraiUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UISamuraiScrollerUnitView.Factory());
            return result;
        }

        private Dictionary<string, IEnhancedUnitViewFactoryV2> GetFormationUnitViewFactories()
        {
            var result = new Dictionary<string, IEnhancedUnitViewFactoryV2>();
            result.Add("", new UIFormationScrollerUnitView.Factory());
            return result;
        }

        private void RefreshDeployList()
        {
            scrollerDeployDel.Reload(Properties.dataDeployList);
        }

        private void RefreshFormationList()
        {
            scrollerFormationDel.Reload(Properties.dataFormationList);
        }

        private void RefreshSamuraiDetailInfo(SamuraiDetailInfo info)
        {
            samuraiDetailInfoView.Refresh(info);
        }
    }

    public class UIPanelDeployProperties : PanelProperties
    {
        public Action onRefreshDeploy;
        public Action onRefreshFormation;
        public Action<SamuraiDetailInfo> onRefreshSamurai;

        public List<EnhancedDataV2> dataDeployList;
        public List<EnhancedDataV2> dataSamuraiList;
        public List<EnhancedDataV2> dataFormationList;

        public void RefreshDeployList()
        {
            onRefreshDeploy?.Invoke();
        }

        public void RefreshFormationList()
        {
            onRefreshFormation?.Invoke();
        }

        public void RefreshSamuraiDetail(SamuraiDetailInfo samuraiDetailInfo)
        {
            onRefreshSamurai?.Invoke(samuraiDetailInfo);
        }
    }
}

///// <summary>
///// 有武将被点击了
///// </summary>
///// <param name="arg1"></param>
///// <param name="arg2"></param>
//private void OnDeploySamuraiUnitClick(string eventName, object uiPanelDeploySamuraiUnitViewUnitData)
//{
//    var data = uiPanelDeploySamuraiUnitViewUnitData as UISamuraiScrollerUnitView.UnitData;
//    SendEvent<EventSamuraiClicked>(data.dto.Id);
//}