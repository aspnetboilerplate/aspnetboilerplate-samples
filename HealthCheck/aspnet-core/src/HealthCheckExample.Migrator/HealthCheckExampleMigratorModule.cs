using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HealthCheckExample.Configuration;
using HealthCheckExample.EntityFrameworkCore;
using HealthCheckExample.Migrator.DependencyInjection;

namespace HealthCheckExample.Migrator
{
    [DependsOn(typeof(HealthCheckExampleEntityFrameworkModule))]
    public class HealthCheckExampleMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public HealthCheckExampleMigratorModule(HealthCheckExampleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(HealthCheckExampleMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                HealthCheckExampleConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(HealthCheckExampleMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
