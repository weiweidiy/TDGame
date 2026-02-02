using Adic;
using Game.Share;
using JFramework;
using JFramework.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{


    public class PlayerModel : BaseModel<PlayerDTO>
    {
        [Inject]
        public PlayerModel(CommonEventManager eventManager) : base(eventManager) { }


        public string GetPlayerUid()
        {
            return data.Uid;
        }

        public string GetUserName()
        {
            return data.Username;
        }
    }




}
