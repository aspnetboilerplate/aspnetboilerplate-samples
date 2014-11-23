using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using AbpWpfDemo.EntityFramework;

namespace AbpWpfDemo
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(AbpWpfDemoCoreModule))]
    public class AbpWpfDemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<AbpWpfDemoDbContext>(null);
        }
    }
}
