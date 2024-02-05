using Abp.Application.Services;
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
                if (typeof (IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
                {
                    //handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationInterceptor>)));
                    //handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationAsyncInterceptor>)));
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationWithPostAsyncActionInterceptor>)));
                }
            };
        }
    }
}
