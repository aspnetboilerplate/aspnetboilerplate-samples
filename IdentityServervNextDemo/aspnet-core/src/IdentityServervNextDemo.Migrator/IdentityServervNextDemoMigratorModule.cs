using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServervNextDemo.Configuration;
using IdentityServervNextDemo.EntityFrameworkCore;
using IdentityServervNextDemo.Migrator.DependencyInjection;

namespace IdentityServervNextDemo.Migrator
{
    [DependsOn(typeof(IdentityServervNextDemoEntityFrameworkModule))]
    public class IdentityServervNextDemoMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityServervNextDemoMigratorModule(IdentityServervNextDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(IdentityServervNextDemoMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                IdentityServervNextDemoConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServervNextDemoMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
