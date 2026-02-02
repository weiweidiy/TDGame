using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace Tiktok
{
    public class CurrenciesModel : BaseDictionaryModel<CurrencyDTO>
    {
        public class EventUpdate : Event { }
        public CurrenciesModel(Func<CurrencyDTO, string> keySelector, EventManager eventManager) : base(keySelector, eventManager)
        {
        }

        public void Initialize(List<CurrencyDTO> currencies)
        {
            AddRange(currencies);
        }

        public void UpdateCurrency(List<CurrencyDTO> currencies)
        {
            Clear();
            AddRange(currencies);

            SendEvent<EventUpdate>(currencies);
        }

        public void AddCurrency(CurrencyDTO currency)
        {
            if (currency == null)
                return;

            var uid = currency.CurrencyType.ToString();
            var data = Get(uid);
            data.Count += currency.Count;
            Update(data);
            SendEvent<EventUpdate>(new List<CurrencyDTO>() { data });
        }

    }

}
