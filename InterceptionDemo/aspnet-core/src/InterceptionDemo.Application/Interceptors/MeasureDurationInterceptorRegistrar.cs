using Abp.Dependency;
using Castle.Core;

namespace InterceptionDemo.Interceptors
{
    internal static class MeasureDurationInterceptorRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += (key, handler) =>
            {
                handler.ComponentModel.Interceptors.Add(
                    new InterceptorReference(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationAsyncInterceptor>))
                );
            };
        }
    }
}
