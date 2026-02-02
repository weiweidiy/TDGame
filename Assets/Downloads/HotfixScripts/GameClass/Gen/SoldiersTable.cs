/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class SoldiersTable : BaseConfigTable<SoldiersCfgData>
    {
    }

    public class SoldiersCfgData : IUnique
    {
        //唯一标识
        public string Uid{ get;set;} 

        //名字
        public string Name;

        //类型
        public int SoldierType;

        //攻击力
        public int Atk;

        //防御力
        public int Def;

        //速度
        public int Speed;

        //技能
        public List<string> Actions;

        //预制体Uid
        public string PrefabUid;

        //预制体spine
        public List<string> Textures;

    }
}
