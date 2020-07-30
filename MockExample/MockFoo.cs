using SharedImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockExample
{
    class MockFoo : IFoo
    {
        public string Bar()
        {
            return "Mock Bar";
        }
    }
}
