using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.Localization;

namespace MultipleDbContextEfCoreDemo
{
    public class MultipleDbContextEfCoreDemoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            MultipleDbContextEfCoreDemoLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoCoreModule).GetAssembly());
        }
    }
}