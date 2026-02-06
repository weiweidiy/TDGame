using deVoid.UIFramework;
using Game.Common;
using Game.Share;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace JFramework.Game.View
{
    [Serializable]
    public class CurrenyMenuItem : UIMenuItem<CurrencyType>
    {
        public TextMeshProUGUI txtCount;
    }

    public class UIPanelCurrencies : UIPanelBaseMenus<CurrencyType, CurrenyMenuItem>
    {
        public class UIPanelCurrenciesPanelData : UIPanelBaseMenusPanelData
        {
        }

        /// <summary>
        /// 兵粮丸进度条
        /// </summary>
        [SerializeField] SingleImageProgressView progressView;

        protected override BasePanelData CreatePanelData()
        {
            return new UIPanelCurrenciesPanelData() { panel = this };
        }

        protected override void OnPanelEnable()
        {
            base.OnPanelEnable();
            (Properties as UIPanelCurrenciesProperties).onRefresh += Properties_onRefresh;
        }


        protected override void OnPanelHide()
        {
            base.OnPanelHide();
            (Properties as UIPanelCurrenciesProperties).onRefresh -= Properties_onRefresh;
        }

        private void Properties_onRefresh()
        {
            OnPanelRefresh(Properties);
        }


        protected override void OnPanelRefresh(UIPanelBaseMenusProperties<CurrencyType> properties)
        {
            base.OnPanelRefresh(properties);
            var currenciesProperties = (properties as UIPanelCurrenciesProperties);

            // 刷新所有货币显示
            var currencyDic = currenciesProperties.CurrencyDict;
            foreach(var item in currencyDic)
            {
                Refresh(item.Key, item.Value);
            }

            // 进度条数据
            var hpProgressData = currenciesProperties.ProgressData;
            progressView.Refresh(hpProgressData);
        }

        TextMeshProUGUI GetText(CurrencyType type)
        {
            foreach (var item in btnMenus)
            {
                if (item.Key == type)
                {
                    return item.txtCount;
                }
            }
            return null;
        }

        void Refresh(CurrencyType currencyType, int count)
        {
            var txtComponent = GetText(currencyType);
            var roller = txtComponent.GetComponent<TMPNumberRoller>();
            if (roller.targetText == null)
            {
                txtComponent.text = count.ToString();
            }
            else
            {
                roller.RollTo(count);
            }
        }
    }

    

    public class UIPanelCurrenciesProperties : UIPanelBaseMenusProperties<CurrencyType>
    {
        public event Action onRefresh;
        public Dictionary<CurrencyType, int> CurrencyDict = new Dictionary<CurrencyType, int>();
        public ProgressData ProgressData;

        public void Refresh()
        {
            onRefresh?.Invoke();
        }
    }
}
//[System.Serializable]
//public struct UICurrencyText
//{
//    public CurrencyType key;
//    public TextMeshProUGUI value;
//}
//public class UIPanelCurrencies : UIPanelBase<UIPanelCurrenciesProperties>
//{
//    public class EventBtnClicked : Event { }


//    [SerializeField] List<UICurrencyText> currencyTexts;

//    protected override void OnPropertiesSet()
//    {
//        base.OnPropertiesSet();
//        Refresh();
//        Properties.onRefresh += Properties_onRefresh;
//    }

//    private void Properties_onRefresh(List<CurrencyType> currenciesTypes)
//    {
//        foreach (var type in currenciesTypes)
//        {
//            Refresh(type);
//        }
//    }

//    void Refresh()
//    {
//        Refresh(CurrencyType.Coin);
//        Refresh(CurrencyType.Pan);
//        //Refresh(CurrencyType.Food);
//    }

//    protected override void WhileHiding()
//    {
//        base.WhileHiding();
//        Properties.onRefresh -= Properties_onRefresh;
//    }

//    TextMeshProUGUI GetText(CurrencyType type)
//    {
//        foreach (var item in currencyTexts)
//        {
//            if (item.key == type)
//            {
//                return item.value;
//            }
//        }
//        return null;
//    }



//    void Refresh(CurrencyType currencyType)
//    {
//        var txtComponent = GetText(currencyType);
//        var roller = txtComponent.GetComponent<TMPNumberRoller>();
//        if (roller.targetText == null)
//        {
//            switch (currencyType)
//            {
//                case CurrencyType.Coin:
//                    txtComponent.text = Properties.Coin.ToString();
//                    break;
//                case CurrencyType.Pan:
//                    txtComponent.text = Properties.Pan.ToString();
//                    break;
//                    //case CurrencyType.Food:
//                    //    txtComponent.text = Properties.Food.ToString();
//                    //    break;
//            }
//        }
//        else
//        {
//            switch (currencyType)
//            {
//                case CurrencyType.Coin:
//                    roller.RollTo(Properties.Coin);
//                    break;
//                case CurrencyType.Pan:
//                    roller.RollTo(Properties.Pan);
//                    break;
//                    //case CurrencyType.Food:
//                    //    roller.RollTo(Properties.Food);
//                    //    break;
//            }
//        }
//    }


//}