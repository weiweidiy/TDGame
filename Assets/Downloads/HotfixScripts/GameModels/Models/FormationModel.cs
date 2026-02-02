using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class FormationModel : BaseDictionaryModel<FormationDTO>
    {
        public class EventUpdate : Event { }

        public FormationModel(Func<FormationDTO, string> keySelector, EventManager eventManager) : base(keySelector, eventManager)
        {
        }

        public void Initialize(List<FormationDTO> formationDTOs)
        {
            AddRange(formationDTOs);
        }

        public void UpdateFormation(FormationDTO formationDTO)
        {
            var data = Get(formationDTO.FormationType.ToString());
            data.FormationBusinessId = formationDTO.FormationBusinessId;
            Update(data);

            SendEvent<EventUpdate>(data);
        }
    }
}
