using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AbpCoreEf7JsonColumnDemo.Authorization.Roles;
using AbpCoreEf7JsonColumnDemo.Authorization.Users;
using AbpCoreEf7JsonColumnDemo.Configuration;
using AbpCoreEf7JsonColumnDemo.Localization;
using AbpCoreEf7JsonColumnDemo.MultiTenancy;
using AbpCoreEf7JsonColumnDemo.Timing;

namespace AbpCoreEf7JsonColumnDemo
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpCoreEf7JsonColumnDemoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AbpCoreEf7JsonColumnDemoLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AbpCoreEf7JsonColumnDemoConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AbpCoreEf7JsonColumnDemoConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = AbpCoreEf7JsonColumnDemoConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf7JsonColumnDemoCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
