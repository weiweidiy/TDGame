using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using UnityEngine;


namespace Tiktok
{
    public class NetworkMessageListener : ViewController
    {
        IJNetwork jNetwork;

        [Inject]
        CurrenciesModel currenciesModel;

        [Inject]
        HpPoolModel hpPoolModel;

        [Inject]
        SamuraisModel samuraiModel;

        [Inject]
        FormationDeployModel formationDeployModel;

        [Inject]
        FormationModel formationModel;

        [Inject]
        CurrentGuideStepModel guideModel;

        [Inject]
        BuildingModel buildingModel;

        [Inject]
        public NetworkMessageListener(EventManager eventManager, IJNetwork jNetwork) : base(eventManager)
        {
            this.jNetwork = jNetwork;
            
        }

        public override void OnStart()
        {
            base.OnStart();
            jNetwork.onMessage += JNetwork_onMessage;
        }

        public override void OnStop()
        {
            base.OnStop();
            jNetwork.onMessage -= JNetwork_onMessage;
        }

        protected override void DoOpen(Open e)
        {
            //throw new System.NotImplementedException();
        }

        private void JNetwork_onMessage(IJNetMessage message)
        {
            switch (message.TypeId)
            {
                case (int)ProtocolType.CurrencyUpdateNtf:
                    {
                        //Debug.Log("CurrencyUpdateNtf");
                        var msgCurrencyUpdateNtf = message as CurrencyUpdateNtf;
                        currenciesModel.UpdateCurrency(msgCurrencyUpdateNtf.CurrencyDTOs);
                    }
                    break;
                case (int)ProtocolType.LevelNodeUpdateNtf:
                    {
                        var msgLevelNodeUpdateNtf = message as LevelNodeUpdateNtf;
                        //levelModel.UpdateLevelNode(msgLevelNodeUpdateNtf.LevelNodeDTOs);
                    }
                    break;
                case (int)ProtocolType.SamuraiUpdateNtf:
                    {
                        var msgSamuraiUpdateNtf = message as SamuraiUpdateNtf;
                        samuraiModel.UpdateSamurai(msgSamuraiUpdateNtf.SamuraiDTOs);
                    }
                    break;
                case (int)ProtocolType.FormationDeployUpdateNtf:
                    {
                        var msgFormationDeployUpdateNtf = message as FormationDeployUpdateNtf;
                        formationDeployModel.UpdateSamuraiDeploy(msgFormationDeployUpdateNtf.FormationDeployDTOs);
                    }
                    break;
                case (int)ProtocolType.HpPoolUpdateNtf:
                    {
                        var msgHpPoolUpdateNtf = message as HpPoolUpdateNtf;
                        hpPoolModel.UpdateHpPool(msgHpPoolUpdateNtf.HpPoolDTO);
                    }
                    break;
                case (int)ProtocolType.FormationUpdateNtf:
                    {
                        var msgFormationUpdateNtf = message as FormationUpdateNtf;
                        formationModel.UpdateFormation(msgFormationUpdateNtf.FormationDTO);
                    }
                    break;
                case (int)ProtocolType.BuildingUpdateNtf:
                    {
                        var msgBuildingUpdateNtf = message as BuildingUpdateNtf;
                        buildingModel.UpdateBuilding(msgBuildingUpdateNtf.BuildingDTO);
                    }
                    break;
                case (int)ProtocolType.CurrentGuideStepUpdateNtf:
                    {
                        var msgCurrentGuideStepUpdateNtf = message as CurrentGuideStepUpdateNtf;
                        Debug.Log("CurrentGuideStepUpdateNtf" + msgCurrentGuideStepUpdateNtf.CurrentGuideStepBusinessId);
                        guideModel.UpdateCurrentGuideStep(msgCurrentGuideStepUpdateNtf.CurrentGuideStepBusinessId);
                    }
                    break;
                default:
                    Debug.LogError($"没有实现消息转发 {message.TypeId}");
                    break;
            }
        }
    }
}
