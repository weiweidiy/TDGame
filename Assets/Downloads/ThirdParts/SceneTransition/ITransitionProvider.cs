using Cysharp.Threading.Tasks;
using JFramework.Common;

namespace JFramework
{
    public interface ITransitionProvider
    {
        UniTask<ITransition>  InstantiateAsync(string transitionType);
    }
}
