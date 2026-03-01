using JFramework.Unity;
using System;

namespace Game
{
    public class BackgroundView : View
    {
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Open<TArg>(TArg args)
        {
            var prefabName = (args as ViewData)?.prefabName;
            var goManager = GetGameObjectManager();
            goManager.Rent(prefabName, null);
        }

        public override void Refresh<TArg>(TArg args)
        {
            throw new NotImplementedException();
        }
    }

}