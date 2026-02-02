using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiktok
{
    public enum SystemType
    {
        Currency,
        Item,
        Samurai,
        Deploy,
    }
    public enum SceneType
    {
        None = 0,
        SceneLogin,
        SceneGuide,
        SceneGame,
        SceneCombat,
        SceneCastle,
    }

    public enum TransitionType
    {
        SMBlindsTransition,
        SMFadeTransition,
    }



    //public enum UILevelNodeMenu
    //{
    //    None = 0,
    //    Attack = 1,
    //    Detail = 2,
    //}

    public enum ActionTiming
    {
        None = 0,
        ActionStart = 1, //行动开始
        ActionEnd = 2, //行动结束
        TurnStart = 3, //回合开始
        TurnEnd = 4, //回合结束
        CombatStart = 5, //战斗开始
        CombatEnd = 6, //战斗结束
        Hurt = 7, //命中/受伤时
    }
}

