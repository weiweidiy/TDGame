using Adic;
using Adic.Container;
using deVoid.UIFramework;
using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using GameCommands;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;
using Event = JFramework.Event;


namespace Tiktok
{
    public class UIDeployController : ViewController
    {
        //public class Open : Event { }
        //public class Close : Event { }
        public class EventDeployUnit : Event { }
        public class EventChangeFormation : Event { }
        public class EventPanelShowed : Event { }
        public class EventPanelClosed : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            public List<FormationDeployDTO> formationDeployDTOs;
            public List<SamuraiDTO> samuraiDTOs;
            public List<FormationDTO> formationDTOs;
        }

        [Inject]
        IInjectionContainer container;
        [Inject]
        protected TiktokGameObjectManager gameObjectManager;
        [Inject]
        protected TiktokConfigManager tiktokConfigManager;
        [Inject]
        protected TiktokSpritesManager spritesManager;
        //[Inject]
        //protected UIManager uiManager;
        [Inject]
        protected ILanguageManager languageManager;

        [Inject]
        protected SamuraisModel samuraisModel;
        [Inject]
        protected FormationDeployModel formationDeployModel;
        [Inject]
        protected FormationModel formationModel;
        [Inject]
        protected BuildingModel buildingModel;

        [Inject]
        protected UIScrollerUnitViewDataConverter dataConverter;

        UIPanelDeployProperties properties;

        IPanelController panel;

        [Inject]
        public UIDeployController(EventManager eventManager) : base(eventManager)
        {
        }
        public override void OnStart()
        {
            base.OnStart();
            eventManager.AddListener<UIPanelEventCloseBtnClicked>(OnCloseDeploy);
            eventManager.AddListener<UIPanelDeploy.EventSamuraiDroped>(OnDeployUnit);
            eventManager.AddListener<UIPanelDeploy.EventRetreatUnit>(OnRetreatUnit);
            eventManager.AddListener<UIPanelDeploy.EventFormationClicked>(OnFormationClicked);
            eventManager.AddListener<UIPanelDeploy.EventSamuraiClicked>(OnSamuraiClicked);
            eventManager.AddListener<UIPanelEventShowed>(OnPanelShowed);


            //数据发生变化时，重新刷新数据
            eventManager.AddListener<FormationDeployModel.EventUpdate>(OnDeployDataUpdate);
            eventManager.AddListener<FormationModel.EventUpdate>(OnFormationUpdate);
        }


        public override void OnStop()
        {
            base.OnStop();
            eventManager.RemoveListener<UIPanelEventCloseBtnClicked>(OnCloseDeploy);
            eventManager.RemoveListener<UIPanelDeploy.EventSamuraiDroped>(OnDeployUnit);
            eventManager.RemoveListener<UIPanelDeploy.EventRetreatUnit>(OnRetreatUnit);
            eventManager.RemoveListener<UIPanelDeploy.EventFormationClicked>(OnFormationClicked);
            eventManager.RemoveListener<UIPanelDeploy.EventSamuraiClicked>(OnSamuraiClicked);
            eventManager.RemoveListener<UIPanelEventShowed>(OnPanelShowed);

            eventManager.RemoveListener<FormationDeployModel.EventUpdate>(OnDeployDataUpdate);
            eventManager.RemoveListener<FormationModel.EventUpdate>(OnFormationUpdate);
        }




        #region 模型数据更新事件

        /// <summary>
        /// 布阵数据更新了，要刷新界面
        /// </summary>
        /// <param name="e"></param>
        private void OnDeployDataUpdate(FormationDeployModel.EventUpdate e)
        {
            if (properties != null)
            {
                var formationDeployDTOs = e.Body as List<FormationDeployDTO>;
                var dataList = ConvertToScrollerDataList(formationDeployDTOs, FormationType.FormationAtk);
                properties.dataDeployList = dataList;
                properties.RefreshDeployList();
            }
        }

        /// <summary>
        /// 当前阵型更新了
        /// </summary>
        /// <param name="e"></param>
        private void OnFormationUpdate(FormationModel.EventUpdate e)
        {
            if (properties != null)
            {
                var formationDTO = e.Body as FormationDTO;
                var arg = new List<FormationDTO>();
                arg.Add(formationDTO);
                var dataList = ConvertToScrollerDataList(arg);
                properties.dataFormationList = dataList;
                properties.RefreshFormationList();
            }
        }

        #endregion

        #region panel交互事件
        /// <summary>
        /// 武将被点击了
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnSamuraiClicked(UIPanelDeploy.EventSamuraiClicked e)
        {
            var samuraiId = (int)e.Body;
            if (properties != null)
            {
                properties.RefreshSamuraiDetail(GetSamuraiDetailInfo(samuraiId));
            }
        }

        /// <summary>
        /// 玩家拖拽武将到布阵点上
        /// </summary>
        /// <param name="e"></param>
        private void OnDeployUnit(UIPanelDeploy.EventSamuraiDroped e)
        {
            var data = e.Body as UIDeployDragableScrollerUnitView.DropData;
            SendEvent<EventDeployUnit>(data);
        }

        /// <summary>
        /// 阵型被点击了
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnFormationClicked(UIPanelDeploy.EventFormationClicked e)
        {
            var formationBusinessId = (string)e.Body;
            SendEvent<EventChangeFormation>(formationBusinessId);
        }


        /// <summary>
        /// 玩家拖拽武将下阵
        /// </summary>
        /// <param name="e"></param>
        private void OnRetreatUnit(UIPanelDeploy.EventRetreatUnit e)
        {
            var data = e.Body as UIDeployDragableScrollerUnitView.DropData;
            var dispatcher = container.GetCommandDispatcher();
            dispatcher.Dispatch<CommandDeploy>(data.formationIndex, -1);
        }

        /// <summary>
        /// 关闭布阵界面
        /// </summary>
        /// <param name="e"></param>
        private void OnCloseDeploy(UIPanelEventCloseBtnClicked e)
        {
            var panelData = e.Body as UIPanelDeploy.UIPanelDeployPanelData;
            if (panelData == null)
                return;
            var panel = panelData.panel;
            uiManager.HidePanel(panel.ScreenId);
            properties = null;
            SendEvent<EventPanelClosed>(panel);
        }

        /// <summary>
        /// panel显示完成
        /// </summary>
        /// <param name="e"></param>
        private void OnPanelShowed(UIPanelEventShowed e)
        {
            var panelData = e.Body as UIPanelDeploy.UIPanelDeployPanelData;
            if (panelData == null)
                return;

            var panel = panelData.panel;
            SendEvent<EventPanelShowed>(panel);
        }
        #endregion

        #region 外部事件

        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            properties = new UIPanelDeployProperties();
            properties.dataDeployList = ConvertToScrollerDataList(controllerArgs.formationDeployDTOs, FormationType.FormationAtk);
            properties.dataSamuraiList = dataConverter.Convert(controllerArgs.samuraiDTOs); // ConvertToScrollerDataList(samuraisModel.GetAll());
            properties.dataFormationList = ConvertToScrollerDataList(controllerArgs.formationDTOs);

            panel = uiManager.ShowPanel(controllerArgs.panelName, properties);
        }
        ///// <summary>
        ///// 打开布阵界面
        ///// </summary>
        ///// <param name="e"></param>
        //private void OnOpenDeploy(Open e)
        //{
        //    properties = new UIPanelDeployProperties();
        //    properties.dataLevelList = ConvertToScrollerDataList(formationDeployModel.GetAll(), FormationType.FormationAtk);
        //    properties.dataSamuraiList = dataConverter.Convert(samuraisModel.GetAll()); // ConvertToScrollerDataList(samuraisModel.GetAll());
        //    properties.dataFormationList = ConvertToScrollerDataList(formationModel.GetAll());

        //    panel = uiManager.ShowPanel(nameof(UIPanelDeploy), properties);
        //}
        #endregion

        public UIPanelDeploy GetPanel()
        {
            return panel as UIPanelDeploy;
        }

        #region 私有方法
        private List<EnhancedDataV2> ConvertToScrollerDataList(List<FormationDeployDTO> formationDeployDTOs, FormationType formationType)
        {
            if (formationDeployDTOs == null || formationDeployDTOs.Count == 0)
                return new List<EnhancedDataV2>();

            //从samuraiDTOs中筛选所有formationType == formationType的DTO
            formationDeployDTOs = formationDeployDTOs.FindAll(dto => dto.FormationType == formationType);
            var formationBusinessId = GetCurrentFormationBusinessId(formationType);
            if (formationBusinessId == null)
            {
                //抛出异常
                throw new Exception("Current formation businessId is null " + formationType);
            }

            var homeData = buildingModel.Get("1");
            var result = new List<EnhancedDataV2>();
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 2, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 1, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 0, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 5, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 4, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 3, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 8, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 7, homeData.Level));
            result.Add(CreateData(formationDeployDTOs, formationBusinessId, 6, homeData.Level));
            return result;
        }

        EnhancedDataV2 CreateData(List<FormationDeployDTO> formationDeployDTOs, string businessId, int index, int homeLevel)
        {
            var valid = tiktokConfigManager.GetFormationPointValidByIndex(businessId, index, homeLevel);
            //从samuraiDTOs中找到PointIndex == i的DTO
            var dto = formationDeployDTOs.Find(dto => dto.FormationPoint == index);
            //如果没有找到，说明这个点没有部署武将

            var data = new EnhancedDataV2();
            var unitData = new UIDeployDragableScrollerUnitView.UnitData();
            unitData.dto = dto;
            unitData.point = index;
            unitData.valid = valid;
            var unlockLevel = tiktokConfigManager.GetFormationPointUnlockLevelByIndex(businessId, index);
            unitData.unlockDesc = unlockLevel == -1 ? "" : string.Format(languageManager.GetText("120004"), unlockLevel);
            unitData.spHead = dto != null ? spritesManager.GetSprite(tiktokConfigManager.GetSamuraiHeadIconBusinessId(GetSamuraiBusinessById(dto.SamuraiId))) : null;
            data.UnitData = unitData;

            //Debug.Log($"CreateDeployData index: {index} valid: {valid} samuraiId: {(dto != null ? dto.SamuraiId.ToString() : "null")}");
            return data;
        }


        private List<EnhancedDataV2> ConvertToScrollerDataList(List<FormationDTO> formationDTOs)
        {
            var result = new List<EnhancedDataV2>();
            var formations = tiktokConfigManager.GetAllFormationBusinessIds();
            foreach (var formationBusinessId in formations)
            {
                var dto = formationDTOs.Find(dto => dto.FormationBusinessId == formationBusinessId);

                var data = new EnhancedDataV2();
                var unitData = new UIFormationScrollerUnitView.UnitData();
                unitData.dto = dto;
                unitData.businessId = formationBusinessId;
                unitData.name = languageManager.GetText(tiktokConfigManager.GetFormationLanguageBusinessId(formationBusinessId));
                unitData.formationIcon = spritesManager.GetSprite(tiktokConfigManager.GetFormationTextureUid(formationBusinessId));

                data.UnitData = unitData;
                result.Add(data);

                //Debug.Log($"ConvertToScrollerDataList formationBusinessId: {formationBusinessId} name: {unitData.name}");
            }
            return result;
        }

        SamuraiDetailInfo GetSamuraiDetailInfo(int samuraiId)
        {
            var dto = samuraisModel.Get(samuraiId.ToString());
            if (dto == null)
                return null;
            var info = new SamuraiDetailInfo();
            info.name = languageManager.GetText(tiktokConfigManager.GetSamuraiNameLid(dto.BusinessId));
            info.level = dto.Level;
            info.hp = dto.CurHp;
            info.maxHp = tiktokConfigManager.GetFormulaMaxHpByLevel(info.level);
            info.exp = dto.Experience;
            info.maxExp = tiktokConfigManager.GetFormulaLevelUpExperience(info.level + 1);
            info.power = tiktokConfigManager.GetSamuraiPower(dto.BusinessId);
            info.def = tiktokConfigManager.GetSamuraiDef(dto.BusinessId);
            info.intel = tiktokConfigManager.GetSamuraiIntel(dto.BusinessId);
            info.soldierName = languageManager.GetText(tiktokConfigManager.GetSoldierNameLid(dto.BusinessId));
            var soliderBusinessId = dto.SoldierBusinessId;
            info.attack = tiktokConfigManager.GetSoldierAttack(soliderBusinessId);
            info.defence = tiktokConfigManager.GetSoldierDefence(soliderBusinessId);
            info.speed = tiktokConfigManager.GetSoldierSpeed(soliderBusinessId);


            return info;
        }


        private string GetCurrentFormationBusinessId(FormationType formationType)
        {
            var curFormation = formationModel.Get(formationType.ToString());
            var curFormationBusinessId = curFormation != null ? curFormation.FormationBusinessId : null;
            return curFormationBusinessId;
        }

        string GetSamuraiBusinessById(int samuraiId)
        {
            var samurai = samuraisModel.Get(samuraiId.ToString());
            if (samurai != null)
                return samurai.BusinessId;
            return null;
        }


        #endregion
    }
}
