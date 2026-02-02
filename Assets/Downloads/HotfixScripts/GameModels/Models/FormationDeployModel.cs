using Game.Share;
using JFramework;
using JFramework.Game;
using System;
using System.Collections.Generic;
using UnityEngine;
using Event = JFramework.Event;


namespace Tiktok
{
    public class FormationDeployModel : BaseDictionaryModel<FormationDeployDTO>
    {
        public class EventUpdate : Event { }
        public FormationDeployModel(Func<FormationDeployDTO, string> keySelector, EventManager eventManager) : base(keySelector, eventManager)
        {
        }

        public void Initialize(List<FormationDeployDTO> formationDTOs)
        {
            AddRange(formationDTOs);
        }

        public void UpdateSamuraiDeploy(List<FormationDeployDTO> formationDeployDTOs)
        {
            Clear();

            //获取formationDeployDTOs中 formationType = atk的
            formationDeployDTOs = formationDeployDTOs.FindAll(dto => dto.FormationType == FormationType.FormationAtk);
           // Debug.LogError($"UpdateSamuraiDeploy formationDeployDTOs count: {formationDeployDTOs.Count}");
            AddRange(formationDeployDTOs);
            SendEvent<EventUpdate>(formationDeployDTOs);
        }
    }
}
