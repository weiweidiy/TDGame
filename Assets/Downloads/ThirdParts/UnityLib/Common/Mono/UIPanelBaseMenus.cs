using deVoid.UIFramework;
using Game.Common;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace JFramework.Game.View
{
    public interface IMenuItem<T>
    {
        T Key { get; }
        AdvancedButton Value { get; }
    }

    [Serializable]
    public class MenuItem<TType> : IMenuItem<TType>
    {
        /// <summary>
        /// 编辑器可见
        /// </summary>
        [SerializeField] TType key;
        [SerializeField] AdvancedButton value;

        /// <summary>
        /// 实现接口
        /// </summary>
        public TType Key => key;
        public AdvancedButton Value => value;
    }

    /// <summary>
    /// 普通菜单基类
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public abstract class UIPanelBaseMenus<TType, TMenuItem> : UIPanelBase<UIPanelBaseMenusProperties<TType>> where TMenuItem : IMenuItem<TType>
    {
        public class UIPanelEventMenuClicked : Event { }

        public class UIPanelBaseMenusPanelData : BasePanelData
        {
            public TMenuItem menuItem;
        }

        [SerializeField] protected List<TMenuItem> btnMenus = new();

        protected override void OnPanelEnable()
        {
            foreach (var btn in btnMenus)
            {
                btn.Value.onClick.AddListener(() =>
                {
                    OnMenuClicked(btn);
                });
            }
        }

        protected override void OnPanelHide()
        {
            foreach (var btn in btnMenus)
            {
                btn.Value.onClick.RemoveAllListeners();
            }
        }

        /// <summary>
        /// 菜单被点击的响应函数
        /// </summary>
        /// <param name="btn"></param>
        protected void OnMenuClicked(TMenuItem btn)
        {
            var panelData = CreatePanelData() as UIPanelBaseMenusPanelData;
            panelData.menuItem = btn;
            SendEvent<UIPanelEventMenuClicked>(panelData);
            Debug.Log($"菜单被点击:{btn.Key}");
        }

        /// <summary>
        /// 刷新菜单数据
        /// </summary>
        /// <param name="properties"></param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void OnPanelRefresh(UIPanelBaseMenusProperties<TType> properties)
        {
            foreach (var btn in btnMenus)
            {
                //Debug.Assert(properties.menuItems != null, $"properties.menuItems == null {btn.Key}");
                //Debug.Assert(properties.menuItems.Contains(btn.Key), $"properties.menuItems.Contains(btn.Key) = false {btn.Key}");
                btn.Value.gameObject.SetActive(properties.menuItems != null && properties.menuItems.Contains(btn.Key));
            }
        }

        /// <summary>
        /// 获取菜单按钮GameObject
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public GameObject GetMenuGameObject(TType key)
        {
            foreach (var btn in btnMenus)
            {
                if (btn.Key.Equals(key))
                    return btn.Value.gameObject;
            }
            return null;
        }
    }


    public abstract class UIPanelBaseMenusProperties<TType> : PanelProperties
    {
        public List<TType> menuItems;
    }
}
