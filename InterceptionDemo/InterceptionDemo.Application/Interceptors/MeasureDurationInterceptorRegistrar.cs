using Abp.Application.Services;
using Castle.Core;
using Castle.MicroKernel;

namespace InterceptionDemo.Interceptors
{
    public static class MeasureDurationInterceptorRegistrar
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(MeasureDurationInterceptor)));

            }
        }
    }
}