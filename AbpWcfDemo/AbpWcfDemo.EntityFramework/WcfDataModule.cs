using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using AbpWcfDemo.EntityFramework;

namespace AbpWcfDemo
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(WcfCoreModule))]
    public class WcfDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<WcfDbContext>(null);
        }
    }
}
