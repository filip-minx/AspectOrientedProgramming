using System;

namespace Minx.AOPExample
{
    public class MyService : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    }
}
