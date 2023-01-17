using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MassTransitSample.Configuration;
using MassTransitSample.EntityFrameworkCore;
using MassTransitSample.Migrator.DependencyInjection;

namespace MassTransitSample.Migrator
{
    [DependsOn(typeof(MassTransitSampleEntityFrameworkModule))]
    public class MassTransitSampleMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MassTransitSampleMigratorModule(MassTransitSampleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MassTransitSampleMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MassTransitSampleConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(MassTransitSampleMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
