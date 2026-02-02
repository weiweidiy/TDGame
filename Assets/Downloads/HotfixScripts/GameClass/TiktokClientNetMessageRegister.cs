using Game.Share;
using JFramework;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class TiktokClientNetMessageRegister : ITypeRegister
    {
        public Dictionary<int, Type> GetTypes()
        {
            var tables = new Dictionary<int, Type>();

            //tables.Add((int)ProtocolType.LoginRes, typeof(LoginRes)); //只需要注册服务器返回的消息类型
            //tables.Add((int)ProtocolType.FightRes, typeof(FightRes));
            //tables.Add((int)ProtocolType.LevelNodeUnlockedNtf, typeof(LevelNodeUnlockedNtf));

            tables.Add((int)ProtocolType.CurrencyUpdateNtf, typeof(CurrencyUpdateNtf));
            tables.Add((int)ProtocolType.SamuraiUpdateNtf, typeof(SamuraiUpdateNtf));
            tables.Add((int)ProtocolType.FormationDeployUpdateNtf, typeof(FormationDeployUpdateNtf));
            tables.Add((int)ProtocolType.LevelNodeUpdateNtf, typeof(LevelNodeUpdateNtf));
            tables.Add((int)ProtocolType.HpPoolUpdateNtf, typeof(HpPoolUpdateNtf));
            tables.Add((int)ProtocolType.FormationUpdateNtf, typeof(FormationUpdateNtf));
            tables.Add((int)ProtocolType.BuildingUpdateNtf, typeof(BuildingUpdateNtf));
            tables.Add((int)ProtocolType.CurrentGuideStepUpdateNtf, typeof(CurrentGuideStepUpdateNtf));

            return tables;
        }
    }
}

