using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDotNetFramework
{
    class ProxyBase<I> : RealProxy where I : class
    {
        I decoratedInstance;

        public ProxyBase() : base(typeof(I)){}

        public ProxyBase(I instance) : base(typeof(I)) {
            decoratedInstance = instance;
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;

            if(methodCall == null)
                throw new ArgumentException(nameof(msg));

            var methodInfo = methodCall.MethodBase as MethodInfo;
            if (methodInfo == null)
                throw new ArgumentException(nameof(msg));

            var args = methodCall.Args;

          

            if (decoratedInstance == null)
            {
                return new ReturnMessage("Interface Only", args, args.Length,
                           methodCall.LogicalCallContext, methodCall);
            }
            else
            {
                var result = typeof(I).InvokeMember(
                         methodCall.MethodName,
                         BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, decoratedInstance, args);
                return new ReturnMessage($"Decorated [{result as string}]", args, args.Length,
                           methodCall.LogicalCallContext, methodCall);
            }

            throw new NotImplementedException();
        }      
    }
}
