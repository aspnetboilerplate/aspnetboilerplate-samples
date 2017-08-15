using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpPerformanceTestApp.Localization;

namespace AbpPerformanceTestApp
{
    public class AbpPerformanceTestAppCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            AbpPerformanceTestAppLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpPerformanceTestAppCoreModule).GetAssembly());
        }
    }
}