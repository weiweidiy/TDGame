using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using Game.Common;
using Game.Share;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiktok;
using UnityEngine;

using static JFramework.Game.View.UIPanelLevelNodeMenus;

namespace JFramework.Game.View
{
    [Serializable]
    public class LevelNodeMenuItem : UIMenuItem<UILevelNodeMenu>
    {
    }

    public class UIPanelLevelNodeMenus : UIPanelBasePopupMenus<UILevelNodeMenu, LevelNodeMenuItem>
    {
        public enum UILevelNodeMenu
        {
            None = 0,
            Attack = 1,
            Detail = 2,
        }

        public class UIPanelLevelNodePanelData : UIPanelBaseMenusPanelData
        {
            public LevelNodeDTO dto;
        }

        /// <summary>
        /// 创建一个PanelData对象
        /// </summary>
        /// <returns></returns>
        protected override BasePanelData CreatePanelData()
        {
            var properties = Properties as UIPanelLevelNodeMenusProperties;
            return new UIPanelLevelNodePanelData() { panel = this , dto = properties.dto};
        }
    }

    public class UIPanelLevelNodeMenusProperties : UIPanelBasePopupMenusProperties<UILevelNodeMenu>
    {
        public LevelNodeDTO dto;
    }




    //public class UIPanelLevelNodeMenus : UIPanelBase<UIPanelLevelNodeMenuProperties>
    //{
    //    [System.Serializable]
    //    public struct UILevelNodeMenuItem
    //    {
    //        public UILevelNodeMenu Key;
    //        public AdvancedButton value;
    //    }

    //    /// <summary>
    //    /// panel的数据
    //    /// </summary>
    //    public class UIPanelBaseMenusPanelData
    //    {
    //        public UIPanelLevelNodeMenus panel;
    //        public UILevelNodeMenu Key;
    //        public LevelNodeDTO dto;
    //    }

    //    #region Events
    //    /// <summary>
    //    /// 点击事件
    //    /// </summary>
    //    public class EventBtnClicked : Event { }
    //    /// <summary>
    //    /// panel显示事件
    //    /// </summary>
    //    public class UIControllerEventPanelShowed : Event { }

    //    #endregion

    //    [SerializeField] List<UILevelNodeMenuItem> btnMenus = new();

    //    protected override void Awake()
    //    {
    //        base.Awake();

    //        foreach (var btn in btnMenus)
    //        {
    //            btn.value.onClicked.AddListener(() =>
    //            {
    //                SendEvent<EventBtnClicked>(new UIPanelBaseMenusPanelData() { panel = this, Key = btn.Key, dto = Properties.dto});
    //            });
    //        }
    //    }
    //    protected override void OnDestroy()
    //    {
    //        base.OnDestroy();

    //        foreach (var btn in btnMenus)
    //        {
    //            btn.value.onClicked.RemoveAllListeners();
    //        }
    //    }

    //    public GameObject GetBtn(UILevelNodeMenu Key)
    //    {
    //        foreach (var btn in btnMenus)
    //        {
    //            if (btn.Key == Key)
    //                return btn.value.gameObject;
    //        }
    //        return null;
    //    }

    //    protected override async void OnPropertiesSet()
    //    {
    //        base.OnPropertiesSet();

    //        transform.position = Properties.worldPosition;

    //        // 等待一帧，确保UI位置更新完毕
    //        await UniTask.Yield(); 
    //        SendEvent<UIControllerEventPanelShowed>(new UIPanelBaseMenusPanelData() { panel = this, Key = UILevelNodeMenu.None, dto = Properties.dto});
    //    }

    //    protected override void WhileHiding()
    //    {
    //        base.WhileHiding();
    //    }
    //}


    //public class UIPanelLevelNodeMenuProperties : PanelProperties
    //{
    //    public UIPanelLevelNodeMenus panel;
    //    public LevelNodeDTO dto;
    //    public Vector2 worldPosition;

    //}
}
