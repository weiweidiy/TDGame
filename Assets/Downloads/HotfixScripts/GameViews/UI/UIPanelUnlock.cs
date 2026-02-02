using deVoid.UIFramework;
using DG.Tweening;
using Game.Common;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace JFramework.Game.View
{
    public class UIPanelUnlock : UIPanelBase<UIPanelUnlockProperties>
    {

        public class UIPanelUnlockPanelData : BasePanelData
        {

        }

        [SerializeField] Image icon;
        [SerializeField] AdvancedButton btnClick;
        Tweener tweener;

        protected override void OnPanelRefresh(UIPanelUnlockProperties properties)
        {
            icon.gameObject.SetActive(Properties.icon != null);
            icon.sprite = Properties.icon;
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelUnlockPanelData() { panel = this };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            tweener?.Kill();
            btnClick.onClick.AddListener(OnClick);
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            tweener?.Kill();
            btnClick.onClick.RemoveListener(OnClick);
        }



        private void OnClick()
        {
            //icon对象飞向目标位置
            if(Properties.targetPos.HasValue)
            {      
                //创建一个icon的克隆对象
                var iconClone = Instantiate(icon, transform);
                tweener = iconClone.transform.DOMove(Properties.targetPos.Value, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Destroy(iconClone.gameObject);
                    SendEvent<UIPanelEventCloseBtnClicked>(CreatePanelData());
                });

                icon.gameObject.SetActive(false);
            }
        }


    }

    public class UIPanelUnlockProperties : PanelProperties
    {
        public Sprite icon;
        public string name;
        public Vector2? targetPos;
    }
}
