using Adic;
using Game.Common;
using JFramework;


namespace Tiktok
{
    public class StepUnlockSystem : BaseGuideStep
    {
        public SystemType SystemType { get; set; }
        public string BusinessId { get; set; }
        [Inject]
        protected TiktokConfigManager configManager;
        [Inject]
        protected TiktokSpritesManager spritesManager;
        protected override void Execute(object arg)
        {
            var businessId = arg as string;
            if (businessId == null)
            {
                var uiArgs = new UIUnlockController.ControllerArgs()
                {
                    SystemType = SystemType,
                    BusinessId = BusinessId
                };
                eventManager.Raise<UIUnlockController.Open>(uiArgs);
            }
        }
    }
}

