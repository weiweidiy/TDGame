using JFramework.Unity;

namespace Game.Demo
{
    public class SceneCastleState : BaseSceneState
    {
        protected override string GetBGMClipName()
        {
            return "";
        }

        protected override DemoSceneType GetSceneType()
        {
            return DemoSceneType.SceneCastle;
        }

        protected override string GetUISettingsName()
        {
            return "UISceneCastleSettings";
        }
    }
}
