using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyCastle
{
    class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.ReturnValue = "Interface Only";
        }
    }
}
