using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyCastle
{
    class Proxy
    {
        internal static I Create<I>(I pocoFoo) where I : class
        {
            var proxy = new ProxyGenerator().CreateInterfaceProxyWithTarget(pocoFoo, new[] { new InterceptorForTarget() });
            return proxy;
        }

        internal static I Create<I>() where I : class
        {
            var proxy = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<I>(new Interceptor());
            return proxy;
        }
    }
}
