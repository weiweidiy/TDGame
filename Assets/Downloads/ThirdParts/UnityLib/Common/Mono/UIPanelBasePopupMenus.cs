using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using Game.Common;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace JFramework.Game.View
{

    /// <summary>
    /// 弹出菜单基类
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public abstract class UIPanelBasePopupMenus<TType, TMenuItem> : UIPanelBaseMenus<TType, TMenuItem> where TMenuItem : IMenuItem<TType>
    {
        protected override void OnPanelRefresh(UIPanelBaseMenusProperties<TType> properties)
        {
            base.OnPanelRefresh(properties);

            var pro = properties as UIPanelBasePopupMenusProperties<TType>;
            transform.position = pro.worldPosition;
        }
    }

    public abstract class UIPanelBasePopupMenusProperties<TType> : UIPanelBaseMenusProperties<TType>
    {
        //public List<TType> menuItems;
        public Vector3 worldPosition;

    }
}
