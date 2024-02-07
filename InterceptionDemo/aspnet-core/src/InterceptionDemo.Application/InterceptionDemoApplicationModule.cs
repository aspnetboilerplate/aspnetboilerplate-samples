using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InterceptionDemo.Authorization;
using InterceptionDemo.Interceptors;

namespace InterceptionDemo
{
    [DependsOn(
        typeof(InterceptionDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class InterceptionDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            MeasureDurationInterceptorRegistrar.Initialize(IocManager);
            Configuration.Authorization.Providers.Add<InterceptionDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(InterceptionDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

            //IocManager.Register(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationInterceptor>), DependencyLifeStyle.Transient);
            //IocManager.Register(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationAsyncInterceptor>), DependencyLifeStyle.Transient);
            IocManager.Register(typeof(AbpAsyncDeterminationInterceptor<MeasureDurationWithPostAsyncActionInterceptor>), DependencyLifeStyle.Transient);
        }
    }
}
