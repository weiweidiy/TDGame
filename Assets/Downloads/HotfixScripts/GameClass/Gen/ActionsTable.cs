/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class ActionsTable : BaseConfigTable<ActionsCfgData>
    {
    }

    public class ActionsCfgData : IUnique
    {
        //唯一标识
        public string Uid{ get;set;} 

        //名字
        public string Name;

        //显示名称
        public int ShowName;

        //角色动画名字
        public string AnimationName;

        /*
        JiChunWei:
1,技能释放时
7,命中/被命中时
        */
        //播放时机
        public int ActionTiming;

        /*
        JiChunWei:
1,技能释放时
7,命中/被命中时
        */
        //命中特效
        public string HitEffect;

    }
}
