using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDotNetFramework
{
    class Proxy<I> where I: class
    {
        public static I Create() {
            var proxy = new ProxyInvoker().GetTransparentProxy();
            return proxy  as I;
        }

        public static I Create(I instance)
        {
            var proxy = new ProxyInvoker(instance).GetTransparentProxy();
            return proxy as I;
        }

        class ProxyInvoker : ProxyBase<I> {
            public ProxyInvoker() : base() { }

            public ProxyInvoker(I instance) : base(instance) { }
        }
    }

    class Proxy
    {
        public static I Create<I>() where I : class
        {
            return Proxy<I>.Create();
        }

        public static I Create<I>(I instance) where I : class
        {
            return Proxy<I>.Create(instance);
        }
    }
}
