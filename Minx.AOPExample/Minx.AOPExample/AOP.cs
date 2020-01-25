using Castle.DynamicProxy;
using System.Collections.Generic;
using System.Linq;

namespace Minx.AOPExample
{
    /// <summary>
    /// Class providing support for aspect oriented programming paradigm.
    /// </summary>
    public static class AOP
    {
        private static ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static IList<Aspect> GlobalAspects = new List<Aspect>();

        public static T AddAspects<T>(T target, params Aspect[] aspects) where T : class
        {
            var targetType = target.GetType();
            var interfaces = targetType.GetInterfaces();

            var allAspects = GlobalAspects.Concat(aspects).ToArray();

            if (typeof(T).IsInterface)
            {
                return (T)ProxyGenerator.CreateInterfaceProxyWithTarget(
                    interfaceToProxy: typeof(T),
                    additionalInterfacesToProxy: interfaces,
                    target: target,
                    interceptors: allAspects);
            }
            else
            {
                return (T)ProxyGenerator.CreateClassProxyWithTarget(
                    classToProxy: targetType,
                    additionalInterfacesToProxy: interfaces,
                    target: target,
                    interceptors: allAspects);
            }
        }
    }
}
