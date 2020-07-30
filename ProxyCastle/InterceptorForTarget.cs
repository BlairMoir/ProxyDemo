using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyCastle
{
    class InterceptorForTarget : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();            
            invocation.ReturnValue = $"Decorated [{invocation.ReturnValue as string}]";
        }
    }
}
