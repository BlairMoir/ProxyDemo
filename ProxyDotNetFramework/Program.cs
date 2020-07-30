using SharedImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            IFoo pocoFoo = new Foo();
            Console.WriteLine(pocoFoo.Bar());

            IFoo decoratedFoo = Proxy.Create<IFoo>(pocoFoo);
            Console.WriteLine(decoratedFoo.Bar());

            IFoo proxyBar = Proxy.Create<IFoo>();
            Console.WriteLine(proxyBar.Bar());

            Console.ReadLine();
        }
    }
}
