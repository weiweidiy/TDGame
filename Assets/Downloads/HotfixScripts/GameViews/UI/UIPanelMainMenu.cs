using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using Game.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiktok;
using UnityEngine;
using static JFramework.Game.View.UIPanelMainMenu;

namespace JFramework.Game.View
{
    [Serializable]
    public class MainMenuItem : MenuItem<UIMainEntrance>
    {
    }
    public class UIPanelMainMenu : UIPanelBaseMenus<UIMainEntrance, MainMenuItem>
    {
        

        public class UIPanelMainMenuPanelData : UIPanelBaseMenusPanelData
        {
            public List<GameObject> activeMenus;
        }

        public enum UIMainEntrance
        {
            None = 0,
            EntranceSamuraisList = 1,
            EntranceDrawSamurai = 2,
            EntranceDeploy = 3,
            EntranceLevel = 4,
            EntranceCastle = 5,
        }

        protected override BasePanelData CreatePanelData()
        {
            //获取所有激活的入口
            var goes = new List<GameObject>();
            foreach (var btn in btnMenus)
            {
                if (btn.Value.gameObject.activeSelf)
                {
                    goes.Add(btn.Value.gameObject);
                }
            }

            return new UIPanelMainMenuPanelData() { panel = this, activeMenus = goes };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            (Properties as UIPanelMainMenuProperties).onRefreshEntrance += OnRefeshEntrances;
        }

        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            (Properties as UIPanelMainMenuProperties).onRefreshEntrance -= OnRefeshEntrances;
        }

        private void OnRefeshEntrances()
        {
            OnPanelRefresh(Properties);
        }
    }



    public class UIPanelMainMenuProperties : UIPanelBaseMenusProperties<UIMainEntrance>
    {
        public event Action onRefreshEntrance;

        public void RefreshEnterance()
        {
            onRefreshEntrance?.Invoke();
        }
    }
}


//public class UIPanelMainMenu : UIPanelBase<UIPanelMainMenuProperties>
//{
//    public class EventBtnClicked : Event { }
//    public class EventPanelShowed : Event { }

//    [SerializeField] List<UIMainEntranceItem> entrances = new();


//    protected override void Awake()
//    {
//        base.Awake();

//        foreach (var btn in entrances)
//        {
//            btn.value.onClick.AddListener(() =>
//            {
//                SendEvent<EventBtnClicked>(btn.Key);
//            });
//        }
//    }
//    protected override void OnDestroy()
//    {
//        base.OnDestroy();

//        foreach (var btn in entrances)
//        {
//            btn.value.onClick.RemoveAllListeners();
//        }
//    }


//    protected override async void OnPropertiesSet()
//    {
//        base.OnPropertiesSet();

//        var goes = new List<GameObject>();
//        // 显示入口
//        if (Properties != null && Properties.openList != null)
//        {
//            foreach (var btn in entrances)
//            {
//                var active = Properties.openList.Contains(btn.Key);
//                btn.value.gameObject.SetActive(active);
//                if (active)
//                {
//                    goes.Add(btn.value.gameObject);
//                }

//            }
//        }
//        else
//        {
//            foreach (var btn in entrances)
//            {
//                btn.value.gameObject.SetActive(false);

//            }
//        }

//        Properties.onRefreshEntrance += OnRefeshEntrances;

//        if(goes.Count > 0)
//        {
//            await UniTask.Yield();
//            SendEvent<EventPanelShowed>(goes);
//        }
//    }

//    protected override void WhileHiding()
//    {
//        base.WhileHiding();


//        Properties.onRefreshEntrance -= OnRefeshEntrances;
//    }



//    private void OnRefeshEntrances()
//    {
//        foreach (var entrance in Properties.openList)
//        {
//            RefreshEntrance(entrance);
//        }
//    }

//    void RefreshEntrance(UIMainEntrance entrance)
//    {
//        var btn = entrances.Find(x => x.Key == entrance);
//        if (btn.value != null)
//        {
//            btn.value.gameObject.SetActive(true);
//            SendEvent<EventPanelShowed>(new List<GameObject>() { btn.value.gameObject });
//        }
//    }

//    public GameObject GetEntrance(UIMainEntrance entrance)
//    {
//        var btn = entrances.Find(x => x.Key == entrance);
//        return btn.value?.gameObject;
//    }


//}