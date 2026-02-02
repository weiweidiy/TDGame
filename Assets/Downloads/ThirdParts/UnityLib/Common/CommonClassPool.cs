using Adic;
using JFramework;

namespace Game.Common
{

    public class CommonClassPool : BaseClassPool
    {
        [Inject]
        public CommonClassPool(ITypeRegister typeRegister) : base(typeRegister, null, null, null)
        {
        }

    }
}

