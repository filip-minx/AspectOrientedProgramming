using Castle.DynamicProxy;
using System;

namespace Minx.AOPExample
{
    public class TracingAspect : Aspect
    {
        public override void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Start of " + invocation.Method.Name);

            invocation.Proceed();

            Console.WriteLine("End of " + invocation.Method.Name);
        }
    }
}
