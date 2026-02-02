using Adic;
using JFramework;

///游戏可以服用
namespace Game.Common
{
    public class CommonDataStore : JDataStore
    {
        [Inject]
        public CommonDataStore(IDataManager dataManager) : base(dataManager)
        {
        }
    }
}
