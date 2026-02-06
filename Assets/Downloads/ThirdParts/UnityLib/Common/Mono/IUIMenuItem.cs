using Game.Common;


namespace JFramework.Game.View
{
    public interface IUIMenuItem<T>
    {
        T Key { get; }
        AdvancedButton Value { get; }
    }
}
