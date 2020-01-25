using System;

namespace Minx.AOPExample
{
    public class Program
    {
        private static void Main()
        {
            // Add a tracing aspect for all future objects.
            AOP.GlobalAspects.Add(new TracingAspect());

            IMyService service = new MyService();

            // Attach aspects to the service.
            service = AOP.AddAspects(service);

            service.DoSomething();

            Console.ReadKey();
        }
    }
}
