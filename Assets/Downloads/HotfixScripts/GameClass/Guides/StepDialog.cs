using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{

    /// <summary>
    /// 引导步骤，每一步引导对应一个步骤类，需要调用Stop方法结束当前步骤
    /// </summary>
    public class StepDialog : BaseGuideStep
    {
        public int DialogGroupId { get; set; }

        [Inject]
        TiktokConfigManager configManager;
        [Inject]
        ILanguageManager languageManager;

        protected override void Execute(object arg)
        {
            //Debug.LogError("Execute dialog " + DialogGroupId);
            ShowDialog(DialogGroupId);
        }

        List<BaseDialogPlayer.DialogData> GetDialogDatas(int groupId)
        {
            var cfgs = configManager.GetDialogDatas(groupId);
            var dialogDataList = new List<BaseDialogPlayer.DialogData>();
            if (cfgs != null)
            {
                
                foreach (var cfg in cfgs)
                {
                    var dialogData = new BaseDialogPlayer.DialogData()
                    {
                        Content = languageManager.GetText(cfg.ContentUid),
                    };
                    dialogDataList.Add(dialogData);
                }
                return dialogDataList;
            }

            return dialogDataList;
        }

        void ShowDialog(int groupId)
        {
            var dialogDataList = GetDialogDatas(groupId);
            var dialogData = new UIDialogController.ControllerArgs()
            {
                DialogGroupId = groupId,
                DataList = dialogDataList
            };
            eventManager.Raise<UIDialogController.Open>(dialogData);
        }



    }
}

