using System;
using JFramework.Unity;
namespace Game
{
public class UIPanelMainBottomView : View
{
    UIPanelMainBottom panel;
    public override void Close()
    {
        throw new System.NotImplementedException();
    }

    public override void Open<TArg>(TArg args)
    {
        panel = GetUIManager().ShowPanel(args.prefabName, new UIPanelMainBottomProperties()) as UIPanelMainBottom;
    }

    public override void Refresh<TArg>(TArg args)
    {
        throw new System.NotImplementedException();
    }
}
}
