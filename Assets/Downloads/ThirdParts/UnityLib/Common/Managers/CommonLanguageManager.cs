using Adic;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;

namespace Game.Common
{
    public class CommonLanguageManager : JLanguageManager
    {
        [Inject]
        public CommonLanguageManager(Func<ILanguage, string> keySelector) : base(keySelector)
        {
        }

        [Inject]
        public override void Initialize(ILanguage[] languages)
        {
            base.Initialize(languages);
            SetCurLanguage(languages[0]);
        }
    }
}

