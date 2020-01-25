using Castle.DynamicProxy;

namespace Minx.AOPExample
{
    public abstract class Aspect : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);
    }
}
