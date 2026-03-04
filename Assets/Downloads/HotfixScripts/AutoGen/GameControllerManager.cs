using JFramework.Unity;


namespace Game
{
    public class GameControllerManager : BaseControllerManager
    {
        public override void RegisterControllers()
        {
            
            controllers.Add(nameof(LoginController), new LoginController());
            controllers.Add(nameof(MatchFightController), new MatchFightController());
            controllers.Add(nameof(StartFightController), new StartFightController());
            
        }
    }
}
