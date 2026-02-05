/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework
{
    public partial class TiktokGenConfigManager : JConfigManager
    {
        public TiktokGenConfigManager(IConfigLoader loader, IDeserializer deserializer) : base(loader)
        {
          RegisterTable<AudiosTable, AudiosCfgData>(nameof(AudiosTable), deserializer);
          RegisterTable<PrefabsTable, PrefabsCfgData>(nameof(PrefabsTable), deserializer);
        }
    }

}
