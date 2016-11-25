using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using PlugInDemo.EntityFramework;

namespace PlugInDemo
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(PlugInDemoCoreModule))]
    public class PlugInDemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PlugInDemoDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
