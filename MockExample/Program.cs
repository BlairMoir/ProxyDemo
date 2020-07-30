using Moq;
using SharedImplementation;
using System;
using System.Diagnostics;

namespace MockExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            var moqMock = new Mock<IFoo>();
            moqMock.Setup(s => s.Bar()).Returns("Moq Bar");
            #endregion

            IFoo[] fooUnderTest = { new Foo(), new MockFoo(), DynamicProxyMock.Create<IFoo>("Mock Bar"), moqMock.Object };
            foreach(var unitUnderTest in fooUnderTest)
            {                
                Debug.Assert(unitUnderTest.Bar() == "Mock Bar");
                Console.WriteLine(unitUnderTest.GetType());
            }
        }
    }
}
