using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockExample
{
    class DynamicProxyMock
    {
        internal static I Create<I>(string response) where I : class
        {
            var proxy = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<I>(new Interceptor(response));
            return proxy;
        }
    }

    internal class Interceptor : IInterceptor
    {
        string response = string.Empty;
        public Interceptor(string response)
        {
            this.response = response;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.ReturnValue = response;
        }
    }
}
