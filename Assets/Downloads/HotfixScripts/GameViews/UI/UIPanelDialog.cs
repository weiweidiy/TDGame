using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using Game.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiktok;
using TMPro;
using UnityEngine;

namespace JFramework.Game.View
{
    /// <summary>
    /// 对话面板，to do: 可以移动到common模块
    /// </summary>
    public class UIPanelDialog : UIPanelBase<UIPanelDialogProperties>
    {
        public class EventDialogComplete : Event { }

        /// <summary>
        /// panel的数据
        /// </summary>
        public class UIPanelDialogPanelData : BasePanelData
        {
            public int DialogGroupId;
        }

        /// <summary>
        /// 通用对话视图,可以替换成其他对话视图
        /// </summary>
        [SerializeField] UICommonDialogView dialogView;

        /// <summary>
        /// 对话播放器
        /// </summary>
        TiktokDialogPlayer player;


        protected override async void OnPanelShow()
        {

            base.OnPanelShow();

            if (Properties.DataList == null || Properties.DataList.Count == 0)
            {
                Debug.LogError("No dialog data provided to UIPanelDialog.");
                return;
            }

            player = new TiktokDialogPlayer(dialogView);
            var extraData = new RunableExtraData()
            {
                Data = Properties.DataList
            };
            await player.Start(extraData);

            //Debug.LogError("UIPanelDialog OnPropertiesSet with data count: " + Properties.DialogGroupId);
            SendEvent<EventDialogComplete>(CreatePanelData());
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            player.Stop();
        }

        protected override void OnPanelRefresh(UIPanelDialogProperties properties)
        {
            //throw new NotImplementedException();
        }

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelDialogPanelData() { panel = this, DialogGroupId = Properties.DialogGroupId };
        }    
    }

    public class UIPanelDialogProperties : PanelProperties
    {
        public int DialogGroupId;
        public List<BaseDialogPlayer.DialogData> DataList;
    }
}
