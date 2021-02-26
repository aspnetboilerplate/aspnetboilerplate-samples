using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf6Sample.Configuration;
using AbpCoreEf6Sample.EntityFramework;
using AbpCoreEf6Sample.Migrator.DependencyInjection;

namespace AbpCoreEf6Sample.Migrator
{
    [DependsOn(typeof(AbpCoreEf6SampleEntityFrameworkModule))]
    public class AbpCoreEf6SampleMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreEf6SampleMigratorModule(AbpCoreEf6SampleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(AbpCoreEf6SampleMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpCoreEf6SampleConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf6SampleMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
