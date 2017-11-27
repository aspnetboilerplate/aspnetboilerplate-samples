using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerDemo.Api.Localization;

namespace IdentityServerDemo.Api
{
    public class ApiCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            ApiLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApiCoreModule).GetAssembly());
        }
    }
}