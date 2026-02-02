using EnhancedScrollerAdvance;
using Game.Common;
using Game.Share;
using System;
using Tiktok;
using UnityEngine;
using UnityEngine.UI;


namespace JFramework.Game.View
{
    public class UIDeployDragableScrollerUnitView : EnhancedUnitViewV2
    {
        public class Factory : EnhancedUnitViewPlaceHolderFactoryV2<UIDeployDragableScrollerUnitView> { }

        public const string OnDrop = "OnDrop";
        public const string OnClick = "OnClick";

        public class DropData
        {
            public int samuraiId;
            public int formationIndex;
        }

        public class UnitData
        {
            public FormationDeployDTO dto;
            public int point;
            public bool valid;
            public Sprite spHead;
            public string unlockDesc;
        }

        GameObject goSlot;
        GameObject goLock;
        Image imgHead;
        BaseSingleTextView txtUnlockLevel;

        DeploySamuraiIconDragHandler dragHandler;

        protected override void OnInitialize()
        {
            imgHead = GetBindingComponent("imgHead") as Image;
            goLock = GetBindingComponent("goLock") as GameObject;
            goSlot = GetBindingComponent("goSlot") as GameObject;
            txtUnlockLevel = GetBindingComponent("txtUnlockLevel") as BaseSingleTextView;

            //给 goSlot 添加拖拽处理器
            var dropHandler = goSlot.GetComponent<CommonUIDropHandler>();
            if (dropHandler == null)
                dropHandler = goSlot.AddComponent<CommonUIDropHandler>();
            dropHandler.onDrop += DropHandler_onDrop;

            //给imgHead 添加拖拽处理器
            dragHandler = imgHead.GetComponent<DeploySamuraiIconDragHandler>();
            if(dragHandler == null)
            {
                dragHandler = imgHead.gameObject.AddComponent<DeploySamuraiIconDragHandler>();
            }
            dragHandler.parent = imgHead.transform.parent.parent.parent.parent.parent; // 设置副本显示在最顶层
            dragHandler.iconImage = imgHead;
            dragHandler.onClicked += DragHandler_onClick;
        }



        public override void OnRefreshCellView()
        {
            var unitData = _data.UnitData as UnitData;
            goLock.SetActive(!unitData.valid);
            Debug.Log($"UIDeployDragableScrollerUnitView OnRefreshCellView point:{unitData.point} valid:{unitData.valid} samuraiId:{(unitData.dto != null ? unitData.dto.SamuraiId.ToString() : "null")} ");
            if (unitData.dto != null && unitData.spHead != null)
            {
                imgHead.sprite = unitData.spHead;
                imgHead.gameObject.SetActive(true);
                dragHandler.TargetArg = new DropData()
                {
                    formationIndex = unitData.point,
                    samuraiId = unitData.dto.SamuraiId,
                };
            }
            else
            {
                imgHead.gameObject.SetActive(false);
                dragHandler.TargetArg = null;
            }

            txtUnlockLevel.gameObject.SetActive(!unitData.valid && unitData.unlockDesc != "");
            txtUnlockLevel.Refresh(unitData.unlockDesc);
        }

        /// <summary>
        /// 有武将拖拽到编队槽位时触发
        /// </summary>
        /// <param name="arg"></param>
        private void DropHandler_onDrop(object arg)
        {
            var par = arg as DropData;

            var samuraiId = par.samuraiId; // (int)properties; // 从arg中获取武士ID
            var unitData = _data.UnitData as UnitData;
            //unitData.dto.SamuraiId = samuraiId; // 更新DTO的SamuraiId
            var dropData = new DropData
            {
                samuraiId = samuraiId,
                formationIndex = unitData.point
            };
            //Debug.Log($"DropHandler_onDrop samuraiId: {dropData.samuraiId} + formationIndex: {dropData.formationIndex}");
            SendUnitCustomEvent(OnDrop, dropData);
        }

        private void DragHandler_onClick(object target)
        {
            var unitData = _data.UnitData as UnitData;
            if(unitData.dto != null)
                SendUnitCustomEvent(OnClick, unitData);
        }
    }
}
