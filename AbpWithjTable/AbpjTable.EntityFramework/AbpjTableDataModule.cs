using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;

namespace AbpjTable
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(AbpjTableCoreModule))]
    public class AbpjTableDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
