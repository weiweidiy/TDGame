using JFramework;
using JFramework.Game;

namespace Game.Common
{
    public class LanguageSC : BaseLanguage
    {
       
        public LanguageSC(IJConfigManager configManager) : base(configManager)
        {
            // 可以在这里使用 configManager 来加载或初始化语言相关的配置
        }

       
        public override string GetText(string uid)
        {
            var cfgData = configManager.Get<LanguagesCfgData>(uid);
            if(cfgData == null)
            {
                return $"[SC] {uid}"; // 如果没有找到对应的配置，返回一个默认值
            }
            return configManager.Get<LanguagesCfgData>(uid).SC;
        }
    }

    public class LanguageTC : BaseLanguage
    {
        public LanguageTC(IJConfigManager configManager) : base(configManager)
        {
            // 可以在这里使用 configManager 来加载或初始化语言相关的配置
        }
        public override string GetText(string uid)
        {
            var cfgData = configManager.Get<LanguagesCfgData>(uid);
            if (cfgData == null)
            {
                return $"[TC] {uid}"; // 如果没有找到对应的配置，返回一个默认值
            }
            return configManager.Get<LanguagesCfgData>(uid).TC;
        }
    }
}

