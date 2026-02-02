/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class BuildingsTable : BaseConfigTable<BuildingsCfgData>
    {
    }

    public class BuildingsCfgData : IUnique
    {
        //唯一标识
        public string Uid{ get;set;} 

        //名字
        public string Name;

        //纹理
        public string PrefabUid;

        //坐标
        public int PositionIndex;

        //菜单
        public List<int> Menus;

        //开启所需关卡
        public int UnlockLevel;

    }
}
