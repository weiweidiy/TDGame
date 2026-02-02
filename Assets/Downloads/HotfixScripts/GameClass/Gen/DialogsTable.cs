/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class DialogsTable : BaseConfigTable<DialogsCfgData>
    {
    }

    public class DialogsCfgData : IUnique
    {
        //唯一标识
        public string Uid{ get;set;} 

        //对话组
        public int GroupId;

        //内容
        public string ContentUid;

        //下一条内容Uid
        public string Next;

    }
}
