using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProxyDotNetCore
{
    public class Proxy<I> : DispatchProxy where I : class
    {
        I decoratedInstance;

        public I Create()
        {
            object proxy = Create<I, Proxy<I>>();
            return proxy as I;
        }

        public I Create(I instance)
        {
            object proxy = Create<I, Proxy<I>>();
            ((Proxy<I>)proxy).decoratedInstance = instance;       
            return proxy as I;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            _ = targetMethod ?? throw new ArgumentException(nameof(targetMethod));

            if(decoratedInstance == null)
            {
                return "Interface Only";
            }
            else
            {
                var result = targetMethod.Invoke(decoratedInstance, args);
                return $"Decorated [{result as string}]";
            }

            throw new NotImplementedException();
        }
    }

    public class Proxy
    {
        public static I Create<I>() where I : class
        {
            object proxy = new Proxy<I>().Create();
            return proxy as I;
        }

        public static I Create<I>(I instance) where I : class
        {
            object proxy = new Proxy<I>().Create(instance);
            return proxy as I;
        }
    }
}
