using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using PlugInDemo.EntityFramework;

namespace PlugInDemo.Migrator
{
    [DependsOn(typeof(PlugInDemoDataModule))]
    public class PlugInDemoMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<PlugInDemoDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}