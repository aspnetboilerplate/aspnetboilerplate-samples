using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using MultipleDbContextDemo.EntityFramework;

namespace MultipleDbContextDemo
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(MultipleDbContextDemoCoreModule))]
    public class MultipleDbContextDemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<MyFirstDbContext>(null);
        }
    }
}
