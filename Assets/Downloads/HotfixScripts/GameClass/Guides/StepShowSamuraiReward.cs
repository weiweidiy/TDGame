using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{
    public class StepShowSamuraiReward : BaseGuideStep
    {
        public string samuraiBusinessId;

        [Inject]
        protected TiktokConfigManager configManager;

        [Inject]
        protected TiktokSpritesManager spritesManager;

        protected override void Execute(object arg)
        {
            var businesId = arg as string;
            if(businesId == null)
            {
                var args = new UIRewardController.CommonRewardArgs();
                var data = new UIRewardController.CommonRewardData();
                data.DataType = SystemType.Samurai;
                data.BusinessId = samuraiBusinessId;
                data.Count = 1;
                args.Rewards.Add(data);
                eventManager.Raise<UIRewardController.OpenCommonReward>(args);
            }
        } 
    }
}

