using JFramework.Package;
using UnityEngine;

public class TiktokInitManager : BaseRunable
{
    protected override void OnRun(RunableExtraData extraData)
    {
        base.OnRun(extraData);

        Debug.Log("init");
        //设置ExtraData
        NotifyComplete(this);
    }
}
