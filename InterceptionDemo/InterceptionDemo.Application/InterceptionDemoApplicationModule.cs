using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using InterceptionDemo.Interceptors;

namespace InterceptionDemo
{
    [DependsOn(typeof(InterceptionDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class InterceptionDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            MeasureDurationInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
