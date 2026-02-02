/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class CurrenciesTable : BaseConfigTable<CurrenciesCfgData>
    {
    }

    public class CurrenciesCfgData : IUnique
    {
        //唯一标识
        public string Uid{ get;set;} 

        //货币名字
        public string Name;

        //货币纹理(小)
        public string SmallTextureUid;

        //货币纹理(大)
        public string BigTextureUid;

    }
}
