using MackySoft.XPool;
using System;
using System.Collections.Generic;

namespace JFramework
{
    /// <summary>
    /// 普通类的对象池
    /// </summary>
    public abstract class BaseClassPool : JObjectPool
    {
        Dictionary<string, object> factories = new Dictionary<string, object>();

        protected BaseClassPool(ITypeRegister typeRegister, Func<Type, Action<object>> rentDelegateFactory = null, Func<Type, Action<object>> returnDelegateFactory = null, Func<Type, Action<object>> releaseDelegateFactory = null) : base(typeRegister, rentDelegateFactory, returnDelegateFactory, releaseDelegateFactory)
        {
        }

        protected override void Regist<T>(Action<T> onRent = null, Action<T> onReturn = null, Action<T> onRelease = null) where T : class
        {
            var pool = new FactoryPool<T>(10, () => new T(), onRent, onReturn, onRelease);
            factories.Add(typeof(T).ToString(), pool);
        }


        public override T Rent<T>(Action<T> onGet = null)// where T : class
        {
            var pool = GetPool<T>();
            var result = pool.Rent();
            onGet?.Invoke(result);
            return result;
        }

        public override void Return<T>(T instance) //where T : class
        {
            var pool = GetPool<T>();
            pool.Return(instance);
        }

        private FactoryPool<T> GetPool<T>() //where T : class
        {
            var key = typeof(T).ToString();
            if (factories.ContainsKey(key))
                return factories[key] as FactoryPool<T>;
            else
                throw new Exception("对象池中没有找到" + key + " 请在classpool的Initialize方法中调用Regist方法！");
        }
    }

}

