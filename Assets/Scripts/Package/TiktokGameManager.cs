using Cysharp.Threading.Tasks;
using JFramework.Package;
using UnityEngine;
using YooAsset;


public class TiktokGameManager : BaseRunable
{
    protected override void OnRun(RunableExtraData extraData)
    {
        base.OnRun(extraData);

        //启动第一个场景
        Debug.Log("GameManager");
        LoadGameEntrance(extraData);
    }

    async void LoadGameEntrance(RunableExtraData extraData)
    {
        var handle = YooAssets.LoadSceneAsync("Persistent");
        await handle.ToUniTask();
        var scene = handle.SceneObject;
    }
}
