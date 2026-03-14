using Cysharp.Threading.Tasks;
using JFramework.Unity;
using UnityEngine.SceneManagement;

namespace Game.Demo
{
    public class SceneCombatState : BaseSceneState
    {
        protected override string GetBGMClipName()
        {
            return "";
        }

        protected override DemoSceneType GetSceneType()
        {
            return DemoSceneType.RoomScene;
        }

        protected override string GetUISettingsName()
        {
            return "UISceneCastleSettings";
        }

        protected async override UniTask<Scene> SwitchScene(string sceneName, SceneMode sceneMode)
        {
            var loadMode = sceneMode == SceneMode.Additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
            var operation = SceneManager.LoadSceneAsync(sceneName, loadMode);
            while (!operation.isDone)
            {
                await UniTask.Yield();
            }
            return SceneManager.GetSceneByName(sceneName);
        }
    }
}
