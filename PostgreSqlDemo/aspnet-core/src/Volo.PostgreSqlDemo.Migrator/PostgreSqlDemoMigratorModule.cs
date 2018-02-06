using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Volo.PostgreSqlDemo.Configuration;
using Volo.PostgreSqlDemo.EntityFrameworkCore;
using Volo.PostgreSqlDemo.Migrator.DependencyInjection;

namespace Volo.PostgreSqlDemo.Migrator
{
    [DependsOn(typeof(PostgreSqlDemoEntityFrameworkModule))]
    public class PostgreSqlDemoMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PostgreSqlDemoMigratorModule(PostgreSqlDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(PostgreSqlDemoMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PostgreSqlDemoConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(PostgreSqlDemoMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
