/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class AchievementsTable : BaseConfigTable<AchievementsCfgData>
    {
    }

    public class AchievementsCfgData : IUnique
    {
        //唯一标识
        public string Uid{ get;set;} 

        //成就参数
        public List<float> Args;

        //成就描述
        public string Desc;

        //奖励
        public string RewardUid;

    }
}
