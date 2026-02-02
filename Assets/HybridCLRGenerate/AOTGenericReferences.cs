using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"DOTween.dll",
		"JFramework.dll",
		"MackySoft.XPool.dll",
		"Main.dll",
		"Microsoft.AspNetCore.SignalR.Client.Core.dll",
		"Newtonsoft.Json.dll",
		"System.Core.dll",
		"UniTask.dll",
		"UnityEngine.CoreModule.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Game.Common.BaseGameObjectPool.<Regist>d__2>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<GameCommands.CommandStartupGame.<InitializeViews>d__13>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__0>d<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__1>d<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__2>d<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.BaseSMAsync.<OnEnter>d__6<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.BaseSMAsync.<OnExit>d__7<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.Common.SMTransitionProvider.<InstantiateAsync>d__1,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.UIManager.<Initialize>d__4>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.YooAssetsLoader.<InstantiateAsync>d__1,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.YooAssetsLoader.<LoadAssetAsync>d__2<object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<JFramework.YooAssetsLoader.<LoadSceneAsync>d__4,UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<SMTransition.<TransitionIn>d__5,int>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<SMTransition.<TransitionOut>d__3,int>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.<EnterStateAsync>d__23<object,object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.<InternalFireAsync>d__18<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.<InternalFireQueuedAsync>d__19<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.OnTransitionedEvent.<InvokeAsync>d__5<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<ActivateAsync>d__5<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<DeactivateAsync>d__6<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<EnterAsync>d__9<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<ExecuteActivationActionsAsync>d__7<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<ExecuteDeactivationActionsAsync>d__8<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<ExecuteEntryActionsAsync>d__11<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<ExecuteExitActionsAsync>d__12<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.BaseSceneState.<OnEnter>d__11>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.BaseSceneState.<OnExit>d__12>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.BaseSceneState.<PlayBGM>d__16>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokGameObjectManager.<Initialize>d__8>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneCastleState.<OnEnter>d__6>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneCombatState.<OnEnter>d__1>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneGameState.<OnEnter>d__1>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneGuideState.<OnEnter>d__5>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneGuideState.<OnExit>d__6>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneLevelBaseState.<OnEnter>d__5>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSceneLoginState.<OnEnter>d__2>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSpritesManager.<Initialize>d__3>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<Tiktok.TiktokSpritesManager.<LoadSpriteAsync>d__4>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Game.Common.BaseGameObjectPool.<Regist>d__2>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<GameCommands.CommandStartupGame.<InitializeViews>d__13>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__0>d<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__1>d<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__2>d<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.BaseSMAsync.<OnEnter>d__6<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.BaseSMAsync.<OnExit>d__7<object,object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.Common.SMTransitionProvider.<InstantiateAsync>d__1,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.UIManager.<Initialize>d__4>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.YooAssetsLoader.<InstantiateAsync>d__1,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.YooAssetsLoader.<LoadAssetAsync>d__2<object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<JFramework.YooAssetsLoader.<LoadSceneAsync>d__4,UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<SMTransition.<TransitionIn>d__5,int>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<SMTransition.<TransitionOut>d__3,int>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.<EnterStateAsync>d__23<object,object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.<InternalFireAsync>d__18<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.<InternalFireQueuedAsync>d__19<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.OnTransitionedEvent.<InvokeAsync>d__5<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<ActivateAsync>d__5<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<DeactivateAsync>d__6<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<EnterAsync>d__9<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<ExecuteActivationActionsAsync>d__7<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<ExecuteDeactivationActionsAsync>d__8<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<ExecuteEntryActionsAsync>d__11<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<ExecuteExitActionsAsync>d__12<object,object>>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.BaseSceneState.<OnEnter>d__11>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.BaseSceneState.<OnExit>d__12>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.BaseSceneState.<PlayBGM>d__16>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokGameObjectManager.<Initialize>d__8>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneCastleState.<OnEnter>d__6>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneCombatState.<OnEnter>d__1>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneGameState.<OnEnter>d__1>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneGuideState.<OnEnter>d__5>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneGuideState.<OnExit>d__6>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneLevelBaseState.<OnEnter>d__5>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSceneLoginState.<OnEnter>d__2>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSpritesManager.<Initialize>d__3>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<Tiktok.TiktokSpritesManager.<LoadSpriteAsync>d__4>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<int>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>
	// Cysharp.Threading.Tasks.CompilerServices.IStateMachineRunnerPromise<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.CompilerServices.IStateMachineRunnerPromise<int>
	// Cysharp.Threading.Tasks.CompilerServices.IStateMachineRunnerPromise<object>
	// Cysharp.Threading.Tasks.ITaskPoolNode<object>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,int>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.IUniTaskSource<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.IUniTaskSource<int>
	// Cysharp.Threading.Tasks.IUniTaskSource<object>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,int>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<int>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<object>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,int>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<int>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<object>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,int>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<int>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<object>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,int>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.UniTask<int>
	// Cysharp.Threading.Tasks.UniTask<object>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<Cysharp.Threading.Tasks.AsyncUnit>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<UnityEngine.SceneManagement.Scene>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<int>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<object>
	// DG.Tweening.Core.DOGetter<float>
	// DG.Tweening.Core.DOSetter<float>
	// EnhancedScrollerAdvance.EnhancedUnitViewPlaceHolderFactoryV2<object>
	// JFramework.DictionaryContainer.<>c__DisplayClass13_0<object>
	// JFramework.DictionaryContainer.<>c__DisplayClass17_0<object>
	// JFramework.DictionaryContainer<object>
	// JFramework.EventManager.<>c__DisplayClass4_0<object>
	// JFramework.EventManager.<>c__DisplayClass7_0<object>
	// JFramework.EventManager.EventDelegate<object>
	// JFramework.Game.BaseConfigTable<object>
	// JFramework.Game.BaseDictionaryModel<object>
	// JFramework.Game.BaseModel<object>
	// JFramework.Game.IConfigTable<object>
	// JFramework.Game.JCombatBasePlayer<object>
	// JFramework.Game.JCombatTurnBasedPlayer<object>
	// JFramework.Game.JCombatTurnBasedReportData<object>
	// MackySoft.XPool.FactoryPool<object>
	// MackySoft.XPool.ObjectModel.PoolBase<object>
	// MackySoft.XPool.Unity.UnityObjectPool<object>
	// Microsoft.AspNetCore.SignalR.Client.HubConnectionExtensions.<>c__DisplayClass2_0<object>
	// System.Action<Cysharp.Threading.Tasks.UniTask>
	// System.Action<Game.Common.RedDotInfo>
	// System.Action<JFramework.Game.ActionEffectInfo>
	// System.Action<JFramework.HandlerWrapper>
	// System.Action<SMTetrisTransition.Tile>
	// System.Action<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Action<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Action<UnityEngine.EventSystems.RaycastResult>
	// System.Action<UnityEngine.Rendering.ScriptableRenderContext,object>
	// System.Action<float>
	// System.Action<int>
	// System.Action<object,Game.Common.RedDotInfo,object>
	// System.Action<object,int,object>
	// System.Action<object,int>
	// System.Action<object,object,object,object>
	// System.Action<object,object,object>
	// System.Action<object,object>
	// System.Action<object>
	// System.Collections.Concurrent.ConcurrentDictionary.<GetEnumerator>d__35<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.DictionaryEnumerator<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Node<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Tables<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary<object,object>
	// System.Collections.Generic.ArraySortHelper<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.ArraySortHelper<Game.Common.RedDotInfo>
	// System.Collections.Generic.ArraySortHelper<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.ArraySortHelper<JFramework.HandlerWrapper>
	// System.Collections.Generic.ArraySortHelper<SMTetrisTransition.Tile>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ArraySortHelper<float>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.Comparer<Game.Common.RedDotInfo>
	// System.Collections.Generic.Comparer<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.Comparer<JFramework.HandlerWrapper>
	// System.Collections.Generic.Comparer<SMTetrisTransition.Tile>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,int>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.Comparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.Comparer<UnityEngine.SceneManagement.Scene>
	// System.Collections.Generic.Comparer<byte>
	// System.Collections.Generic.Comparer<float>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.Dictionary.Enumerator<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<int,int>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.Dictionary<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<Game.Common.RedDotInfo>
	// System.Collections.Generic.EqualityComparer<JFramework.HandlerWrapper>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,int>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.EqualityComparer<UnityEngine.SceneManagement.Scene>
	// System.Collections.Generic.EqualityComparer<byte>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.ICollection<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.ICollection<Game.Common.RedDotInfo>
	// System.Collections.Generic.ICollection<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.ICollection<JFramework.HandlerWrapper>
	// System.Collections.Generic.ICollection<SMTetrisTransition.Tile>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,JFramework.HandlerWrapper>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ICollection<float>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.IComparer<Game.Common.RedDotInfo>
	// System.Collections.Generic.IComparer<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.IComparer<JFramework.HandlerWrapper>
	// System.Collections.Generic.IComparer<SMTetrisTransition.Tile>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IComparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IComparer<float>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IDictionary<int,object>
	// System.Collections.Generic.IDictionary<object,LitJson.ArrayMetadata>
	// System.Collections.Generic.IDictionary<object,LitJson.ObjectMetadata>
	// System.Collections.Generic.IDictionary<object,LitJson.PropertyMetadata>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.IEnumerable<Game.Common.RedDotInfo>
	// System.Collections.Generic.IEnumerable<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.IEnumerable<JFramework.HandlerWrapper>
	// System.Collections.Generic.IEnumerable<SMTetrisTransition.Tile>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,JFramework.HandlerWrapper>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IEnumerable<float>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.IEnumerator<Game.Common.RedDotInfo>
	// System.Collections.Generic.IEnumerator<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.IEnumerator<JFramework.HandlerWrapper>
	// System.Collections.Generic.IEnumerator<SMTetrisTransition.Tile>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,JFramework.HandlerWrapper>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IEnumerator<float>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.IList<Game.Common.RedDotInfo>
	// System.Collections.Generic.IList<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.IList<JFramework.HandlerWrapper>
	// System.Collections.Generic.IList<SMTetrisTransition.Tile>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.IList<float>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>
	// System.Collections.Generic.KeyValuePair<object,JFramework.HandlerWrapper>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.List.Enumerator<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.List.Enumerator<Game.Common.RedDotInfo>
	// System.Collections.Generic.List.Enumerator<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.List.Enumerator<JFramework.HandlerWrapper>
	// System.Collections.Generic.List.Enumerator<SMTetrisTransition.Tile>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List.Enumerator<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.List.Enumerator<float>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.List<Game.Common.RedDotInfo>
	// System.Collections.Generic.List<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.List<JFramework.HandlerWrapper>
	// System.Collections.Generic.List<SMTetrisTransition.Tile>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.List<float>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.Generic.ObjectComparer<Game.Common.RedDotInfo>
	// System.Collections.Generic.ObjectComparer<JFramework.Game.ActionEffectInfo>
	// System.Collections.Generic.ObjectComparer<JFramework.HandlerWrapper>
	// System.Collections.Generic.ObjectComparer<SMTetrisTransition.Tile>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,int>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.ObjectComparer<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.Generic.ObjectComparer<UnityEngine.SceneManagement.Scene>
	// System.Collections.Generic.ObjectComparer<byte>
	// System.Collections.Generic.ObjectComparer<float>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<Game.Common.RedDotInfo>
	// System.Collections.Generic.ObjectEqualityComparer<JFramework.HandlerWrapper>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,int>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.ObjectEqualityComparer<UnityEngine.SceneManagement.Scene>
	// System.Collections.Generic.ObjectEqualityComparer<byte>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Queue.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.Queue.Enumerator<deVoid.UIFramework.WindowHistoryEntry>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.Queue<deVoid.UIFramework.WindowHistoryEntry>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.Stack.Enumerator<deVoid.UIFramework.WindowHistoryEntry>
	// System.Collections.Generic.Stack<deVoid.UIFramework.WindowHistoryEntry>
	// System.Collections.ObjectModel.ReadOnlyCollection<Cysharp.Threading.Tasks.UniTask>
	// System.Collections.ObjectModel.ReadOnlyCollection<Game.Common.RedDotInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<JFramework.Game.ActionEffectInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<JFramework.HandlerWrapper>
	// System.Collections.ObjectModel.ReadOnlyCollection<SMTetrisTransition.Tile>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.EventSystems.RaycastResult>
	// System.Collections.ObjectModel.ReadOnlyCollection<float>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<Cysharp.Threading.Tasks.UniTask>
	// System.Comparison<Game.Common.RedDotInfo>
	// System.Comparison<JFramework.Game.ActionEffectInfo>
	// System.Comparison<JFramework.HandlerWrapper>
	// System.Comparison<SMTetrisTransition.Tile>
	// System.Comparison<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Comparison<UnityEngine.EventSystems.RaycastResult>
	// System.Comparison<float>
	// System.Comparison<int>
	// System.Comparison<object>
	// System.EventHandler<object>
	// System.Func<Cysharp.Threading.Tasks.UniTask>
	// System.Func<System.Collections.Generic.KeyValuePair<int,object>,byte>
	// System.Func<System.Collections.Generic.KeyValuePair<int,object>,int>
	// System.Func<System.Collections.Generic.KeyValuePair<int,object>,object>
	// System.Func<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,byte>
	// System.Func<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>
	// System.Func<System.Collections.Generic.KeyValuePair<object,object>,byte>
	// System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Func<System.Threading.Tasks.VoidTaskResult>
	// System.Func<byte>
	// System.Func<int,byte>
	// System.Func<int,object>
	// System.Func<int>
	// System.Func<object,Cysharp.Threading.Tasks.UniTask>
	// System.Func<object,System.Threading.Tasks.VoidTaskResult>
	// System.Func<object,byte>
	// System.Func<object,int,Cysharp.Threading.Tasks.UniTask>
	// System.Func<object,int,object,Cysharp.Threading.Tasks.UniTask>
	// System.Func<object,int>
	// System.Func<object,object,Cysharp.Threading.Tasks.UniTask>
	// System.Func<object,object,byte>
	// System.Func<object,object,object,Cysharp.Threading.Tasks.UniTask>
	// System.Func<object,object,object,byte>
	// System.Func<object,object,object,object,Cysharp.Threading.Tasks.UniTask>
	// System.Func<object,object,object,object>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.IObservable<Game.Common.RedDotInfo>
	// System.IObserver<Game.Common.RedDotInfo>
	// System.Linq.Buffer<object>
	// System.Linq.Enumerable.<ConcatIterator>d__59<object>
	// System.Linq.Enumerable.<DistinctIterator>d__68<object>
	// System.Linq.Enumerable.<ExceptIterator>d__77<object>
	// System.Linq.Enumerable.<OfTypeIterator>d__97<object>
	// System.Linq.Enumerable.<SelectManyIterator>d__17<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.<SelectManyIterator>d__17<object,object>
	// System.Linq.Enumerable.<UnionIterator>d__71<object>
	// System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Linq.Enumerable.Iterator<int>
	// System.Linq.Enumerable.Iterator<object>
	// System.Linq.Enumerable.WhereArrayIterator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Linq.Enumerable.WhereArrayIterator<object>
	// System.Linq.Enumerable.WhereEnumerableIterator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Linq.Enumerable.WhereEnumerableIterator<int>
	// System.Linq.Enumerable.WhereEnumerableIterator<object>
	// System.Linq.Enumerable.WhereListIterator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Linq.Enumerable.WhereListIterator<object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>
	// System.Linq.Enumerable.WhereSelectArrayIterator<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<object,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<object,object>
	// System.Linq.Enumerable.WhereSelectListIterator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>
	// System.Linq.Enumerable.WhereSelectListIterator<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.WhereSelectListIterator<object,object>
	// System.Linq.EnumerableSorter<object,int>
	// System.Linq.EnumerableSorter<object>
	// System.Linq.OrderedEnumerable.<GetEnumerator>d__1<object>
	// System.Linq.OrderedEnumerable<object,int>
	// System.Linq.OrderedEnumerable<object>
	// System.Linq.Set<object>
	// System.Nullable<System.DateTime>
	// System.Nullable<UnityEngine.Vector2>
	// System.Nullable<byte>
	// System.Predicate<Cysharp.Threading.Tasks.UniTask>
	// System.Predicate<Game.Common.RedDotInfo>
	// System.Predicate<JFramework.Game.ActionEffectInfo>
	// System.Predicate<JFramework.HandlerWrapper>
	// System.Predicate<SMTetrisTransition.Tile>
	// System.Predicate<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Predicate<UnityEngine.EventSystems.RaycastResult>
	// System.Predicate<float>
	// System.Predicate<int>
	// System.Predicate<object>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.TaskAwaiter<byte>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.Task<byte>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskCompletionSource<byte>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<byte>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.TaskFactory<byte>
	// System.Threading.Tasks.TaskFactory<object>
	// System.Tuple<object,object>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,int>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>>
	// System.ValueTuple<byte,System.ValueTuple<byte,int>>
	// System.ValueTuple<byte,System.ValueTuple<byte,object>>
	// System.ValueTuple<byte,UnityEngine.SceneManagement.Scene>
	// System.ValueTuple<byte,int>
	// System.ValueTuple<byte,object>
	// System.ValueTuple<int,int>
	// }}

	public void RefMethods()
	{
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameCommands.CommandStartupGame.<InitializeViews>d__13>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameCommands.CommandStartupGame.<InitializeViews>d__13&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__0>d<object,object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__0>d<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__1>d<object,object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__1>d<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__2>d<object,object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__2>d<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.BaseSMAsync.<OnEnter>d__6<object,object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.BaseSMAsync.<OnEnter>d__6<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.BaseSMAsync.<OnExit>d__7<object,object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.BaseSMAsync.<OnExit>d__7<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.<InternalFireAsync>d__18<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.<InternalFireAsync>d__18<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.<InternalFireQueuedAsync>d__19<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.<InternalFireQueuedAsync>d__19<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.OnTransitionedEvent.<InvokeAsync>d__5<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.OnTransitionedEvent.<InvokeAsync>d__5<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<ActivateAsync>d__5<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<ActivateAsync>d__5<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<DeactivateAsync>d__6<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<DeactivateAsync>d__6<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<EnterAsync>d__9<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<EnterAsync>d__9<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<ExecuteActivationActionsAsync>d__7<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<ExecuteActivationActionsAsync>d__7<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<ExecuteDeactivationActionsAsync>d__8<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<ExecuteDeactivationActionsAsync>d__8<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<ExecuteEntryActionsAsync>d__11<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<ExecuteEntryActionsAsync>d__11<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<ExecuteExitActionsAsync>d__12<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<ExecuteExitActionsAsync>d__12<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.BaseSceneState.<OnEnter>d__11>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.BaseSceneState.<OnEnter>d__11&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.BaseSceneState.<OnExit>d__12>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.BaseSceneState.<OnExit>d__12&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokGameObjectManager.<Initialize>d__8>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokGameObjectManager.<Initialize>d__8&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneCastleState.<OnEnter>d__6>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneCastleState.<OnEnter>d__6&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneCombatState.<OnEnter>d__1>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneCombatState.<OnEnter>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneGameState.<OnEnter>d__1>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneGameState.<OnEnter>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneGuideState.<OnEnter>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneGuideState.<OnEnter>d__5&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneGuideState.<OnExit>d__6>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneGuideState.<OnExit>d__6&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneLevelBaseState.<OnEnter>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneLevelBaseState.<OnEnter>d__5&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneLoginState.<OnEnter>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneLoginState.<OnEnter>d__2&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSpritesManager.<Initialize>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSpritesManager.<Initialize>d__3&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<UnityEngine.SceneManagement.Scene>,Tiktok.BaseSceneState.<OnEnter>d__11>(Cysharp.Threading.Tasks.UniTask.Awaiter<UnityEngine.SceneManagement.Scene>&,Tiktok.BaseSceneState.<OnEnter>d__11&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Game.Common.BaseGameObjectPool.<Regist>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Game.Common.BaseGameObjectPool.<Regist>d__2&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,JFramework.UIManager.<Initialize>d__4>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,JFramework.UIManager.<Initialize>d__4&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Tiktok.TiktokSpritesManager.<LoadSpriteAsync>d__4>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Tiktok.TiktokSpritesManager.<LoadSpriteAsync>d__4&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.YieldAwaitable.Awaiter,Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>>(Cysharp.Threading.Tasks.YieldAwaitable.Awaiter&,Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,GameCommands.CommandStartupGame.<InitializeViews>d__13>(System.Runtime.CompilerServices.TaskAwaiter&,GameCommands.CommandStartupGame.<InitializeViews>d__13&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.BaseSceneState.<PlayBGM>d__16>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.BaseSceneState.<PlayBGM>d__16&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<UnityEngine.SceneManagement.Scene>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.YooAssetsLoader.<LoadSceneAsync>d__4>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.YooAssetsLoader.<LoadSceneAsync>d__4&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,SMTransition.<TransitionIn>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter&,SMTransition.<TransitionIn>d__5&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,SMTransition.<TransitionOut>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,SMTransition.<TransitionOut>d__3&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.YooAssetsLoader.<InstantiateAsync>d__1>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.YooAssetsLoader.<InstantiateAsync>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,JFramework.YooAssetsLoader.<LoadAssetAsync>d__2<object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,JFramework.YooAssetsLoader.<LoadAssetAsync>d__2<object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.<EnterStateAsync>d__23<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.<EnterStateAsync>d__23<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,JFramework.Common.SMTransitionProvider.<InstantiateAsync>d__1>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,JFramework.Common.SMTransitionProvider.<InstantiateAsync>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Stateless.StateMachine.<EnterStateAsync>d__23<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Stateless.StateMachine.<EnterStateAsync>d__23<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Game.Common.BaseGameObjectPool.<Regist>d__2>(Game.Common.BaseGameObjectPool.<Regist>d__2&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<GameCommands.CommandStartupGame.<InitializeViews>d__13>(GameCommands.CommandStartupGame.<InitializeViews>d__13&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__0>d<object,object,object>>(JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__0>d<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__1>d<object,object,object>>(JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__1>d<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__2>d<object,object,object>>(JFramework.BaseSMAsync.<>c__DisplayClass5_0.<<Initialize>b__2>d<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<JFramework.BaseSMAsync.<OnEnter>d__6<object,object,object>>(JFramework.BaseSMAsync.<OnEnter>d__6<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<JFramework.BaseSMAsync.<OnExit>d__7<object,object,object>>(JFramework.BaseSMAsync.<OnExit>d__7<object,object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<JFramework.UIManager.<Initialize>d__4>(JFramework.UIManager.<Initialize>d__4&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>>(Stateless.StateMachine.<HandleReentryTriggerAsync>d__21<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>>(Stateless.StateMachine.<HandleTransitioningTriggerAsync>d__22<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.<InternalFireAsync>d__18<object,object>>(Stateless.StateMachine.<InternalFireAsync>d__18<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>>(Stateless.StateMachine.<InternalFireOneAsync>d__20<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.<InternalFireQueuedAsync>d__19<object,object>>(Stateless.StateMachine.<InternalFireQueuedAsync>d__19<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.OnTransitionedEvent.<InvokeAsync>d__5<object,object>>(Stateless.StateMachine.OnTransitionedEvent.<InvokeAsync>d__5<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<ActivateAsync>d__5<object,object>>(Stateless.StateMachine.StateRepresentation.<ActivateAsync>d__5<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<DeactivateAsync>d__6<object,object>>(Stateless.StateMachine.StateRepresentation.<DeactivateAsync>d__6<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<EnterAsync>d__9<object,object>>(Stateless.StateMachine.StateRepresentation.<EnterAsync>d__9<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<ExecuteActivationActionsAsync>d__7<object,object>>(Stateless.StateMachine.StateRepresentation.<ExecuteActivationActionsAsync>d__7<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<ExecuteDeactivationActionsAsync>d__8<object,object>>(Stateless.StateMachine.StateRepresentation.<ExecuteDeactivationActionsAsync>d__8<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<ExecuteEntryActionsAsync>d__11<object,object>>(Stateless.StateMachine.StateRepresentation.<ExecuteEntryActionsAsync>d__11<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Stateless.StateMachine.StateRepresentation.<ExecuteExitActionsAsync>d__12<object,object>>(Stateless.StateMachine.StateRepresentation.<ExecuteExitActionsAsync>d__12<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.BaseSceneState.<OnEnter>d__11>(Tiktok.BaseSceneState.<OnEnter>d__11&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.BaseSceneState.<OnExit>d__12>(Tiktok.BaseSceneState.<OnExit>d__12&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.BaseSceneState.<PlayBGM>d__16>(Tiktok.BaseSceneState.<PlayBGM>d__16&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokGameObjectManager.<Initialize>d__8>(Tiktok.TiktokGameObjectManager.<Initialize>d__8&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneCastleState.<OnEnter>d__6>(Tiktok.TiktokSceneCastleState.<OnEnter>d__6&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneCombatState.<OnEnter>d__1>(Tiktok.TiktokSceneCombatState.<OnEnter>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneGameState.<OnEnter>d__1>(Tiktok.TiktokSceneGameState.<OnEnter>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneGuideState.<OnEnter>d__5>(Tiktok.TiktokSceneGuideState.<OnEnter>d__5&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneGuideState.<OnExit>d__6>(Tiktok.TiktokSceneGuideState.<OnExit>d__6&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneLevelBaseState.<OnEnter>d__5>(Tiktok.TiktokSceneLevelBaseState.<OnEnter>d__5&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSceneLoginState.<OnEnter>d__2>(Tiktok.TiktokSceneLoginState.<OnEnter>d__2&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSpritesManager.<Initialize>d__3>(Tiktok.TiktokSpritesManager.<Initialize>d__3&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<Tiktok.TiktokSpritesManager.<LoadSpriteAsync>d__4>(Tiktok.TiktokSpritesManager.<LoadSpriteAsync>d__4&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<UnityEngine.SceneManagement.Scene>.Start<JFramework.YooAssetsLoader.<LoadSceneAsync>d__4>(JFramework.YooAssetsLoader.<LoadSceneAsync>d__4&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<int>.Start<SMTransition.<TransitionIn>d__5>(SMTransition.<TransitionIn>d__5&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<int>.Start<SMTransition.<TransitionOut>d__3>(SMTransition.<TransitionOut>d__3&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<JFramework.Common.SMTransitionProvider.<InstantiateAsync>d__1>(JFramework.Common.SMTransitionProvider.<InstantiateAsync>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<JFramework.YooAssetsLoader.<InstantiateAsync>d__1>(JFramework.YooAssetsLoader.<InstantiateAsync>d__1&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<JFramework.YooAssetsLoader.<LoadAssetAsync>d__2<object>>(JFramework.YooAssetsLoader.<LoadAssetAsync>d__2<object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Stateless.StateMachine.<EnterStateAsync>d__23<object,object>>(Stateless.StateMachine.<EnterStateAsync>d__23<object,object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>>(Stateless.StateMachine.StateRepresentation.<ExitAsync>d__10<object,object>&)
		// Cysharp.Threading.Tasks.UniTask.Awaiter Cysharp.Threading.Tasks.EnumeratorAsyncExtensions.GetAwaiter<object>(object)
		// object DG.Tweening.TweenSettingsExtensions.OnComplete<object>(object,DG.Tweening.TweenCallback)
		// object DG.Tweening.TweenSettingsExtensions.OnStepComplete<object>(object,DG.Tweening.TweenCallback)
		// object DG.Tweening.TweenSettingsExtensions.SetDelay<object>(object,float)
		// object DG.Tweening.TweenSettingsExtensions.SetEase<object>(object,DG.Tweening.Ease)
		// object DG.Tweening.TweenSettingsExtensions.SetLoops<object>(object,int)
		// object DG.Tweening.TweenSettingsExtensions.SetLoops<object>(object,int,DG.Tweening.LoopType)
		// object DG.Tweening.TweenSettingsExtensions.SetUpdate<object>(object,DG.Tweening.UpdateType)
		// System.Void JFramework.EventManager.AddListener<object>(JFramework.EventManager.EventDelegate<object>,bool)
		// object JFramework.EventManager.GetEvent<object>(object)
		// System.Void JFramework.EventManager.Raise<object>(object)
		// System.Void JFramework.EventManager.RemoveListener<object>(JFramework.EventManager.EventDelegate<object>)
		// System.Void JFramework.EventManager.ReturnEvent<object>(object)
		// System.Void JFramework.Game.BaseDictionaryModel<object>.SendEvent<object>(object)
		// System.Void JFramework.Game.BaseModel<object>.SendEvent<object>(object)
		// System.Void JFramework.Game.IJConfigManager.RegisterTable<object,object>(string,JFramework.IDeserializer)
		// System.Void JFramework.Game.JConfigManager.RegisterTable<object,object>(string,JFramework.IDeserializer)
		// object JFramework.IDeserializer.ToObject<object>(byte[])
		// object JFramework.IDeserializer.ToObject<object>(string)
		// object JFramework.IObjectPool.Rent<object>(System.Action<object>)
		// System.Void JFramework.IObjectPool.Return<object>(object)
		// object LitJson.JsonMapper.ToObject<object>(string)
		// System.IDisposable Microsoft.AspNetCore.SignalR.Client.HubConnectionExtensions.On<object>(Microsoft.AspNetCore.SignalR.Client.HubConnection,string,System.Action<object>)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string,Newtonsoft.Json.JsonSerializerSettings)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// bool System.Array.Exists<object>(object[],System.Predicate<object>)
		// int System.Array.FindIndex<object>(object[],System.Predicate<object>)
		// int System.Array.FindIndex<object>(object[],int,int,System.Predicate<object>)
		// bool System.Linq.Enumerable.All<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// bool System.Linq.Enumerable.Any<object>(System.Collections.Generic.IEnumerable<object>)
		// bool System.Linq.Enumerable.Any<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Concat<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.ConcatIterator<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>)
		// int System.Linq.Enumerable.Count<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Distinct<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.DistinctIterator<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Except<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.ExceptIterator<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEqualityComparer<object>)
		// object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>)
		// object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.OfType<object>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.OfTypeIterator<object>(System.Collections.IEnumerable)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.OrderByDescending<object,int>(System.Collections.Generic.IEnumerable<object>,System.Func<object,int>)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>,System.Func<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<object,object>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectMany<System.Collections.Generic.KeyValuePair<object,object>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,System.Collections.Generic.IEnumerable<object>>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectMany<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Collections.Generic.IEnumerable<object>>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectManyIterator<System.Collections.Generic.KeyValuePair<object,object>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,System.Collections.Generic.IEnumerable<object>>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectManyIterator<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Collections.Generic.IEnumerable<object>>)
		// object System.Linq.Enumerable.SingleOrDefault<object>(System.Collections.Generic.IEnumerable<object>)
		// object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.Dictionary<object,object> System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<object,object>,object,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>)
		// System.Collections.Generic.Dictionary<object,object> System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<object,object>,object,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Union<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.UnionIterator<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>> System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<object,object>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,bool>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Where<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>>.Select<int>(System.Func<System.Collections.Generic.KeyValuePair<object,Game.Common.RedDotInfo>,int>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,object>>.Select<object>(System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<object>.Select<object>(System.Func<object,object>)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter,Game.Common.DoTweenFadePlayer.<Play>d__3>(Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter&,Game.Common.DoTweenFadePlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter,Game.Common.DoTweenMoveUpPlayer.<Play>d__4>(Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter&,Game.Common.DoTweenMoveUpPlayer.<Play>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Game.Common.DoTweenFadePlayer.<Play>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Game.Common.DoTweenFadePlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Game.Common.DoTweenUniTaskDelayPlayer.<Play>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Game.Common.DoTweenUniTaskDelayPlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.CombatUnitSpinePlayer.<FadeOut>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.CombatUnitSpinePlayer.<FadeOut>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokCombatView.<Play>d__13>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokCombatView.<Play>d__13&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Tiktok.TiktokJCombatAnimationPlayer.<InitFormationUnits>d__23>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Tiktok.TiktokJCombatAnimationPlayer.<InitFormationUnits>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.BaseDialogPlayer.<OnStartAync>d__3>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.BaseDialogPlayer.<OnStartAync>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.GuideManager.<RunNext>d__6>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.GuideManager.<RunNext>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.GuideManager.<Start>d__4>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.GuideManager.<Start>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__2>d>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__2>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__3>d>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__3>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__4>d>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__4>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.CombatUnitSpinePlayer.<PlayDead>d__4>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.CombatUnitSpinePlayer.<PlayDead>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<Initialize>d__22<object>>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<Initialize>d__22<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayAcion>d__34>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayAcion>d__34&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionHitAnimation>d__37>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionHitAnimation>d__37&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionName>d__40>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionName>d__40&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayDamageText>d__39>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayDamageText>d__39&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayHittedActionName>d__38>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayHittedActionName>d__38&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,Game.Common.GuideManager.<Start>d__4>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,Game.Common.GuideManager.<Start>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,Game.Common.UICommonDialogView.<Say>d__11>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,Game.Common.UICommonDialogView.<Say>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Common.GameAudioManager.<PlayMusic>d__10>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Common.GameAudioManager.<PlayMusic>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Common.GameAudioManager.<PlaySound>d__9>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Common.GameAudioManager.<PlaySound>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.UIRewardController.<ShowNextReward>d__21>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.UIRewardController.<ShowNextReward>d__21&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.YieldAwaitable.YieldAwaiter,Game.Common.UnityHttpRequest.<SendRequest>d__15>(System.Runtime.CompilerServices.YieldAwaitable.YieldAwaiter&,Game.Common.UnityHttpRequest.<SendRequest>d__15&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter,Game.Common.DoTweenFadePlayer.<Play>d__3>(Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter&,Game.Common.DoTweenFadePlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter,Game.Common.DoTweenMoveUpPlayer.<Play>d__4>(Cysharp.Threading.Tasks.DOTweenAsyncExtensions.TweenAwaiter&,Game.Common.DoTweenMoveUpPlayer.<Play>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Game.Common.DoTweenFadePlayer.<Play>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Game.Common.DoTweenFadePlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Game.Common.DoTweenUniTaskDelayPlayer.<Play>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Game.Common.DoTweenUniTaskDelayPlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.CombatUnitSpinePlayer.<FadeOut>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.CombatUnitSpinePlayer.<FadeOut>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokCombatView.<Play>d__13>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokCombatView.<Play>d__13&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Tiktok.TiktokJCombatAnimationPlayer.<InitFormationUnits>d__23>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Tiktok.TiktokJCombatAnimationPlayer.<InitFormationUnits>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.BaseDialogPlayer.<OnStartAync>d__3>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.BaseDialogPlayer.<OnStartAync>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.GuideManager.<RunNext>d__6>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.GuideManager.<RunNext>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.GuideManager.<Start>d__4>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.GuideManager.<Start>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__2>d>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__2>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__3>d>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__3>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__4>d>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__4>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.CombatUnitSpinePlayer.<PlayDead>d__4>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.CombatUnitSpinePlayer.<PlayDead>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<Initialize>d__22<object>>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<Initialize>d__22<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayAcion>d__34>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayAcion>d__34&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionHitAnimation>d__37>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionHitAnimation>d__37&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionName>d__40>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayActionName>d__40&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayDamageText>d__39>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayDamageText>d__39&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.TiktokJCombatAnimationPlayer.<PlayHittedActionName>d__38>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.TiktokJCombatAnimationPlayer.<PlayHittedActionName>d__38&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,Game.Common.GuideManager.<Start>d__4>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,Game.Common.GuideManager.<Start>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,Game.Common.UICommonDialogView.<Say>d__11>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,Game.Common.UICommonDialogView.<Say>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Common.GameAudioManager.<PlayMusic>d__10>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Common.GameAudioManager.<PlayMusic>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Common.GameAudioManager.<PlaySound>d__9>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Common.GameAudioManager.<PlaySound>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.UIRewardController.<ShowNextReward>d__21>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.UIRewardController.<ShowNextReward>d__21&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.YieldAwaitable.YieldAwaiter,Game.Common.UnityHttpRequest.<SendRequest>d__15>(System.Runtime.CompilerServices.YieldAwaitable.YieldAwaiter&,Game.Common.UnityHttpRequest.<SendRequest>d__15&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Game.Common.GameAudioManager.<LoadAudioClip>d__17>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Game.Common.GameAudioManager.<LoadAudioClip>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,JFramework.YooAssetsLoader.<LoadBytesAsync>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,JFramework.YooAssetsLoader.<LoadBytesAsync>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Tiktok.UIRewardController.<ConvertToScrollerDataList>d__22>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Tiktok.UIRewardController.<ConvertToScrollerDataList>d__22&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.UnityHttpRequest.<DeleteAsync>d__12>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.UnityHttpRequest.<DeleteAsync>d__12&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.UnityHttpRequest.<GetAsync>d__6>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.UnityHttpRequest.<GetAsync>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.UnityHttpRequest.<PostAsync>d__10>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.UnityHttpRequest.<PostAsync>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.UnityHttpRequest.<PostAsync>d__9>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.UnityHttpRequest.<PostAsync>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<PostBodyAsync>d__5<object,object>>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<PostBodyAsync>d__5<object,object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestChangeFormation>d__11>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestChangeFormation>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestCompleteGuideStep>d__12>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestCompleteGuideStep>d__12&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestCreateBuilding>d__14>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestCreateBuilding>d__14&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestDeploy>d__10>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestDeploy>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestDraw>d__9>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestDraw>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestEnterGame>d__7>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestEnterGame>d__7&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestFight>d__8>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestFight>d__8&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestLogin>d__6>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestLogin>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestMatch>d__16>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestMatch>d__16&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuilding>d__13>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuilding>d__13&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuildingImmediately>d__15>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuildingImmediately>d__15&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.BaseDialogPlayer.<OnStartAync>d__3>(Game.Common.BaseDialogPlayer.<OnStartAync>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.DoTweenFadePlayer.<Play>d__3>(Game.Common.DoTweenFadePlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.DoTweenMoveUpPlayer.<Play>d__4>(Game.Common.DoTweenMoveUpPlayer.<Play>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.DoTweenUniTaskDelayPlayer.<Play>d__3>(Game.Common.DoTweenUniTaskDelayPlayer.<Play>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.GameAudioManager.<PlayMusic>d__10>(Game.Common.GameAudioManager.<PlayMusic>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.GameAudioManager.<PlaySound>d__9>(Game.Common.GameAudioManager.<PlaySound>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.GuideManager.<RunNext>d__6>(Game.Common.GuideManager.<RunNext>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.GuideManager.<Start>d__4>(Game.Common.GuideManager.<Start>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__2>d>(Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__2>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__3>d>(Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__3>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__4>d>(Game.Common.SignalRSocket.<>c__DisplayClass17_0.<<Init>b__4>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.UICommonDialogView.<Say>d__11>(Game.Common.UICommonDialogView.<Say>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Game.Common.UnityHttpRequest.<SendRequest>d__15>(Game.Common.UnityHttpRequest.<SendRequest>d__15&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.CombatUnitSpinePlayer.<FadeOut>d__5>(Tiktok.CombatUnitSpinePlayer.<FadeOut>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.CombatUnitSpinePlayer.<PlayDead>d__4>(Tiktok.CombatUnitSpinePlayer.<PlayDead>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokCombatView.<Play>d__13>(Tiktok.TiktokCombatView.<Play>d__13&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<InitFormationUnits>d__23>(Tiktok.TiktokJCombatAnimationPlayer.<InitFormationUnits>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<Initialize>d__22<object>>(Tiktok.TiktokJCombatAnimationPlayer.<Initialize>d__22<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<PlayAcion>d__34>(Tiktok.TiktokJCombatAnimationPlayer.<PlayAcion>d__34&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<PlayActionHitAnimation>d__37>(Tiktok.TiktokJCombatAnimationPlayer.<PlayActionHitAnimation>d__37&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<PlayActionName>d__40>(Tiktok.TiktokJCombatAnimationPlayer.<PlayActionName>d__40&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<PlayDamageText>d__39>(Tiktok.TiktokJCombatAnimationPlayer.<PlayDamageText>d__39&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.TiktokJCombatAnimationPlayer.<PlayHittedActionName>d__38>(Tiktok.TiktokJCombatAnimationPlayer.<PlayHittedActionName>d__38&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<Tiktok.UIRewardController.<ShowNextReward>d__21>(Tiktok.UIRewardController.<ShowNextReward>d__21&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Common.GameAudioManager.<LoadAudioClip>d__17>(Game.Common.GameAudioManager.<LoadAudioClip>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Common.UnityHttpRequest.<DeleteAsync>d__12>(Game.Common.UnityHttpRequest.<DeleteAsync>d__12&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Common.UnityHttpRequest.<GetAsync>d__6>(Game.Common.UnityHttpRequest.<GetAsync>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Common.UnityHttpRequest.<PostAsync>d__10>(Game.Common.UnityHttpRequest.<PostAsync>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Common.UnityHttpRequest.<PostAsync>d__9>(Game.Common.UnityHttpRequest.<PostAsync>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<JFramework.YooAssetsLoader.<LoadBytesAsync>d__3>(JFramework.YooAssetsLoader.<LoadBytesAsync>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<PostBodyAsync>d__5<object,object>>(Tiktok.TiktokUnityHttpRequest.<PostBodyAsync>d__5<object,object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestChangeFormation>d__11>(Tiktok.TiktokUnityHttpRequest.<RequestChangeFormation>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestCompleteGuideStep>d__12>(Tiktok.TiktokUnityHttpRequest.<RequestCompleteGuideStep>d__12&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestCreateBuilding>d__14>(Tiktok.TiktokUnityHttpRequest.<RequestCreateBuilding>d__14&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestDeploy>d__10>(Tiktok.TiktokUnityHttpRequest.<RequestDeploy>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestDraw>d__9>(Tiktok.TiktokUnityHttpRequest.<RequestDraw>d__9&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestEnterGame>d__7>(Tiktok.TiktokUnityHttpRequest.<RequestEnterGame>d__7&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestFight>d__8>(Tiktok.TiktokUnityHttpRequest.<RequestFight>d__8&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestLogin>d__6>(Tiktok.TiktokUnityHttpRequest.<RequestLogin>d__6&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestMatch>d__16>(Tiktok.TiktokUnityHttpRequest.<RequestMatch>d__16&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuilding>d__13>(Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuilding>d__13&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuildingImmediately>d__15>(Tiktok.TiktokUnityHttpRequest.<RequestUpgradeBuildingImmediately>d__15&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Tiktok.UIRewardController.<ConvertToScrollerDataList>d__22>(Tiktok.UIRewardController.<ConvertToScrollerDataList>d__22&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameCommands.CommandFight.<Execute>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameCommands.CommandFight.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameCommands.CommandFightReturnBack.<Execute>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameCommands.CommandFightReturnBack.<Execute>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameCommands.CommandLogin.<Execute>d__17>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameCommands.CommandLogin.<Execute>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameCommands.CommandStartupGame.<Execute>d__10>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameCommands.CommandStartupGame.<Execute>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameCommands.CommandSwitchScene.<Execute>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameCommands.CommandSwitchScene.<Execute>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,Tiktok.TiktokSceneGuideState.<InitGuideManager>d__13>(Cysharp.Threading.Tasks.UniTask.Awaiter&,Tiktok.TiktokSceneGuideState.<InitGuideManager>d__13&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<int>,GameCommands.CommandFight.<Execute>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter<int>&,GameCommands.CommandFight.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<int>,GameCommands.CommandFightReturnBack.<Execute>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter<int>&,GameCommands.CommandFightReturnBack.<Execute>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<int>,GameCommands.CommandLogin.<Execute>d__17>(Cysharp.Threading.Tasks.UniTask.Awaiter<int>&,GameCommands.CommandLogin.<Execute>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<int>,GameCommands.CommandSwitchScene.<Execute>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter<int>&,GameCommands.CommandSwitchScene.<Execute>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<int>,Tiktok.GameLevelBackgroundViewController.<OnSwitchLevel>d__16>(Cysharp.Threading.Tasks.UniTask.Awaiter<int>&,Tiktok.GameLevelBackgroundViewController.<OnSwitchLevel>d__16&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,GameCommands.CommandFight.<Execute>d__5>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,GameCommands.CommandFight.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,GameCommands.CommandFightReturnBack.<Execute>d__3>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,GameCommands.CommandFightReturnBack.<Execute>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,GameCommands.CommandLogin.<Execute>d__17>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,GameCommands.CommandLogin.<Execute>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,GameCommands.CommandSwitchScene.<Execute>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,GameCommands.CommandSwitchScene.<Execute>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter<object>,Tiktok.GameLevelBackgroundViewController.<OnSwitchLevel>d__16>(Cysharp.Threading.Tasks.UniTask.Awaiter<object>&,Tiktok.GameLevelBackgroundViewController.<OnSwitchLevel>d__16&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.YieldAwaitable.Awaiter,JFramework.Game.View.UIPanelBase.<OnPropertiesSet>d__6<object>>(Cysharp.Threading.Tasks.YieldAwaitable.Awaiter&,JFramework.Game.View.UIPanelBase.<OnPropertiesSet>d__6<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.DoTweenFadePlayer.<OnEnable>d__2>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.DoTweenFadePlayer.<OnEnable>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.DoTweenMoveUpPlayer.<OnEnable>d__2>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.DoTweenMoveUpPlayer.<OnEnable>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.DoTweenUniTaskDelayPlayer.<OnEnable>d__1>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.DoTweenUniTaskDelayPlayer.<OnEnable>d__1&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<Close>d__19>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<Close>d__19&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<Open>d__18>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<Open>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Game.Common.SignalRSocket.<Send>d__20>(System.Runtime.CompilerServices.TaskAwaiter&,Game.Common.SignalRSocket.<Send>d__20&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,GameCommands.CommandLogin.<Execute>d__17>(System.Runtime.CompilerServices.TaskAwaiter&,GameCommands.CommandLogin.<Execute>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,JFramework.Game.View.UIPanelDialog.<OnPanelShow>d__4>(System.Runtime.CompilerServices.TaskAwaiter&,JFramework.Game.View.UIPanelDialog.<OnPanelShow>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,Tiktok.CombatViewController.<DoOpen>d__11>(System.Runtime.CompilerServices.TaskAwaiter&,Tiktok.CombatViewController.<DoOpen>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandChangeFormation.<Execute>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandChangeFormation.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandCompleteBuildingUpgrade.<Execute>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandCompleteBuildingUpgrade.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandCompleteGuide.<Execute>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandCompleteGuide.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandCreateBuilding.<Execute>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandCreateBuilding.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandDeploy.<Execute>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandDeploy.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandDraw.<Execute>d__5>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandDraw.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandFight.<Execute>d__5>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandFight.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandLogin.<Execute>d__17>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandLogin.<Execute>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,GameCommands.CommandUpgradeBuilding.<Execute>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,GameCommands.CommandUpgradeBuilding.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Game.Common.DoTweenFadePlayer.<OnEnable>d__2>(Game.Common.DoTweenFadePlayer.<OnEnable>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Game.Common.DoTweenMoveUpPlayer.<OnEnable>d__2>(Game.Common.DoTweenMoveUpPlayer.<OnEnable>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Game.Common.DoTweenUniTaskDelayPlayer.<OnEnable>d__1>(Game.Common.DoTweenUniTaskDelayPlayer.<OnEnable>d__1&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Game.Common.SignalRSocket.<Close>d__19>(Game.Common.SignalRSocket.<Close>d__19&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Game.Common.SignalRSocket.<Open>d__18>(Game.Common.SignalRSocket.<Open>d__18&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Game.Common.SignalRSocket.<Send>d__20>(Game.Common.SignalRSocket.<Send>d__20&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandChangeFormation.<Execute>d__4>(GameCommands.CommandChangeFormation.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandCompleteBuildingUpgrade.<Execute>d__4>(GameCommands.CommandCompleteBuildingUpgrade.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandCompleteGuide.<Execute>d__4>(GameCommands.CommandCompleteGuide.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandCreateBuilding.<Execute>d__4>(GameCommands.CommandCreateBuilding.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandDeploy.<Execute>d__4>(GameCommands.CommandDeploy.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandDraw.<Execute>d__5>(GameCommands.CommandDraw.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandFight.<Execute>d__5>(GameCommands.CommandFight.<Execute>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandFightReturnBack.<Execute>d__3>(GameCommands.CommandFightReturnBack.<Execute>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandLogin.<Execute>d__17>(GameCommands.CommandLogin.<Execute>d__17&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandStartupGame.<Execute>d__10>(GameCommands.CommandStartupGame.<Execute>d__10&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandSwitchScene.<Execute>d__2>(GameCommands.CommandSwitchScene.<Execute>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameCommands.CommandUpgradeBuilding.<Execute>d__4>(GameCommands.CommandUpgradeBuilding.<Execute>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<JFramework.Game.View.UIPanelBase.<OnPropertiesSet>d__6<object>>(JFramework.Game.View.UIPanelBase.<OnPropertiesSet>d__6<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<JFramework.Game.View.UIPanelDialog.<OnPanelShow>d__4>(JFramework.Game.View.UIPanelDialog.<OnPanelShow>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Tiktok.CombatViewController.<DoOpen>d__11>(Tiktok.CombatViewController.<DoOpen>d__11&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Tiktok.GameLevelBackgroundViewController.<OnSwitchLevel>d__16>(Tiktok.GameLevelBackgroundViewController.<OnSwitchLevel>d__16&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Tiktok.TiktokSceneGuideState.<InitGuideManager>d__13>(Tiktok.TiktokSceneGuideState.<InitGuideManager>d__13&)
		// object& System.Runtime.CompilerServices.Unsafe.As<object,object>(object&)
		// System.Void* System.Runtime.CompilerServices.Unsafe.AsPointer<object>(object&)
		// System.Threading.Tasks.Task<byte> System.Threading.Tasks.Task.FromResult<byte>(byte)
		// System.Threading.Tasks.Task<object> System.Threading.Tasks.Task.FromResult<object>(object)
		// object UnityEngine.Component.GetComponent<object>()
		// object[] UnityEngine.Component.GetComponents<object>()
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
		// object[] UnityEngine.GameObject.GetComponents<object>()
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.YooAssets.LoadAssetAsync<object>(string,uint)
	}
}