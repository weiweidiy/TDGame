/*
* 此类由ConfigTools自动生成. 不要手动修改!
*/
using System.Collections;
using System.Collections.Generic;
using JFramework.Game;

namespace JFramework.Unity
{
    public partial class GenConfigManager : JConfigManager
    {
        public GenConfigManager(IConfigLoader loader, IDeserializer deserializer) : base(loader)
        {
          RegisterTable<PrefabsTable, PrefabsCfgData>(nameof(PrefabsTable), deserializer);
          RegisterTable<TexturesTable, TexturesCfgData>(nameof(TexturesTable), deserializer);
        }
    }

}
