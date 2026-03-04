using JFramework.Unity;
using System.Collections.Generic;

namespace Game
{
    public class GameControllerManager : BaseControllerManager
    {

        public override void RegisterControllers()
        {
            controllers.Add(nameof(LoginController), new LoginController());
            controllers.Add(nameof(StartFightController), new StartFightController());

        }
    }

}