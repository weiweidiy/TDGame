using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game;
using JFramework.Game.View;
using System;
using System.Collections.Generic;


namespace Tiktok
{
    public class TiktokClassRegister : ITypeRegister
    {
        int index;
        public Dictionary<int, Type> GetTypes()
        {
            var result = new Dictionary<int, Type>();



            //请求对象
            result.Add(GetIndex(), typeof(RequestFight));
            result.Add(GetIndex(), typeof(RequestDrawSamurai));
            result.Add(GetIndex(), typeof(RequestAddSamuraiExp));
            result.Add(GetIndex(), typeof(RequestDeploy));
            result.Add(GetIndex(), typeof(RequestChangeFormation));
            result.Add(GetIndex(), typeof(RequestCompleteGuideStep));
            result.Add(GetIndex(), typeof(RequestUpgradeBuilding));
            result.Add(GetIndex(), typeof(RequestCreateBuilding));
            result.Add(GetIndex(), typeof(RequestMatch));

            //response对象
            result.Add(GetIndex(), typeof(LevelNodeDTO));
            result.Add(GetIndex(), typeof(ResponseFight));

            //事件
            result.Add(GetIndex(), typeof(EventFight));


            result.Add(GetIndex(), typeof(EventExitLevel));
            result.Add(GetIndex(), typeof(EventSwitchLevel));
            result.Add(GetIndex(), typeof(EventRequestCombat));
            result.Add(GetIndex(), typeof(EventExitCombat));
            result.Add(GetIndex(), typeof(EventDrawSamurai));

            //模型事件
            result.Add(GetIndex(), typeof(CurrenciesModel.EventUpdate));
            result.Add(GetIndex(), typeof(HpPoolModel.EventUpdate));
            result.Add(GetIndex(), typeof(FormationDeployModel.EventUpdate));
            result.Add(GetIndex(), typeof(FormationModel.EventUpdate));
            result.Add(GetIndex(), typeof(SamuraisModel.EventUpdate));
            result.Add(GetIndex(), typeof(BuildingModel.EventUpdate));
            result.Add(GetIndex(), typeof(BuildingModel.EventCreate));
            result.Add(GetIndex(), typeof(CurrentGuideStepModel.EventUpdate));
            result.Add(GetIndex(), typeof(LevelsModel.EventLevelNodeUpdate));

            //UI事件
            result.Add(GetIndex(), typeof(UIPanelEventShowed));
            result.Add(GetIndex(), typeof(UIPanelEventCloseBtnClicked));
            result.Add(GetIndex(), typeof(UIPanelMainMenu. UIPanelEventMenuClicked));
            result.Add(GetIndex(), typeof(UIPanelLevelNodeMenus.UIPanelEventMenuClicked));
            result.Add(GetIndex(), typeof(UIPanelBuildingMenus.UIPanelEventMenuClicked));
            result.Add(GetIndex(), typeof(UIPanelCurrencies.UIPanelEventMenuClicked));

            //登录
            result.Add(GetIndex(), typeof(UIPanelLogin.EventBtnEnterClick));
            result.Add(GetIndex(), typeof(UILoginController.EventEnterGame));

            //城堡
            result.Add(GetIndex(), typeof(CastleBackgroundViewController.EventEnterCastle));
            result.Add(GetIndex(), typeof(CastleBuildingsViewController.EventBuildingClicked));
            result.Add(GetIndex(), typeof(CastleBackgroundViewController.EventBuildingCreateClicked));
            result.Add(GetIndex(), typeof(UIBuildingMenuController.EventBuildingPopupMenuClicked));



            //UIMainMenuController
            result.Add(GetIndex(), typeof(UIMainMenuController.EventUpdateEntrances));
            result.Add(GetIndex(), typeof(UIMainMenuController.EventPanelShowed));
            result.Add(GetIndex(), typeof(UIMainMenuController.EventEnteranceClicked));


            result.Add(GetIndex(), typeof(GameLevelNodeViewController.EventLevelNodeClicked));
            result.Add(GetIndex(), typeof(GameLevelNodeViewController.EventNodeShow));
            result.Add(GetIndex(), typeof(GameLevelBackgroundViewController.EventEnterLevel));

            result.Add(GetIndex(), typeof(UIPanelLevelNodeDetail.EventDeploySamuraiClicked));  
            result.Add(GetIndex(), typeof(UILevelNodeDetailController.EventPanelShowed));
                     

            //levelnodemenu
            //result.Add(GetIndex(), typeof(UILevelNodeMenuController.Open));
            result.Add(GetIndex(), typeof(UILevelNodeMenuController.UIControllerEventPanelShowed));
            result.Add(GetIndex(), typeof(UILevelNodeMenuController.UIControllerEventAttackClicked));


            result.Add(GetIndex(), typeof(ViewController.Open));
            result.Add(GetIndex(), typeof(ViewController.Close));


            //布阵

            result.Add(GetIndex(), typeof(UIPanelDeploy.EventFormationClicked));
            result.Add(GetIndex(), typeof(UIPanelDeploy.EventSamuraiClicked));
            result.Add(GetIndex(), typeof(UIPanelDeploy.EventSamuraiDroped));
            result.Add(GetIndex(), typeof(UIPanelDeploy.EventRetreatUnit));
            result.Add(GetIndex(), typeof(UIDeployController.EventDeployUnit));
            result.Add(GetIndex(), typeof(UIDeployController.EventChangeFormation));
            result.Add(GetIndex(), typeof(UIDeployController.EventPanelShowed));
            result.Add(GetIndex(), typeof(UIDeployController.EventPanelClosed));


            //奖励
            result.Add(GetIndex(), typeof(UIRewardController.OpenCombatReward));
            result.Add(GetIndex(), typeof(UIRewardController.OpenCommonReward));
            result.Add(GetIndex(), typeof(UIRewardController.EventCombatRewardReceived));
            result.Add(GetIndex(), typeof(UIRewardController.EventRewardComplete));


            //战斗
            result.Add(GetIndex(), typeof(TiktokCombatPlayer.EventUnitCast));
            result.Add(GetIndex(), typeof(TiktokCombatPlayer.EventUnitHurt));


            //新手引导
            result.Add(GetIndex(), typeof(UIPanelDialog.EventDialogComplete));
            result.Add(GetIndex(), typeof(UIDialogController.EventDialogCompleted));

            //关卡列表
            result.Add(GetIndex(), typeof(UIPanelLevelList.EventCellClicked));
            result.Add(GetIndex(), typeof(UILevelListController.EventCellClicked));


            //其他对象
            result.Add(GetIndex(), typeof(JCombatTurnBasedEventRunner));
            result.Add(GetIndex(), typeof(RunableExtraData));
            return result;
        }

        int GetIndex()
        {
            return index++;
        }
    }

    public class EventFight : Event { }
    
}

