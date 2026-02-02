using Adic;
using JFramework;

namespace Game.Common
{
    public class CommonJNetMessageJsonSerializerStrate : JNetMessageJsonSerializerStrate
    {
        [Inject]
        public CommonJNetMessageJsonSerializerStrate(IDataConverter dataConverter) : base(dataConverter)
        {
        }
    }
}

