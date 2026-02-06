using Game.Common;


namespace JFramework.Game.View
{
    public interface IMenuItem<T>
    {
        T key { get; }
        IClickHandler value { get; }
    }
}
