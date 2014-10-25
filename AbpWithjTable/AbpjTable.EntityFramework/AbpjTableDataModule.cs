using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using AbpjTable.EntityFramework;

namespace AbpjTable
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(AbpjTableCoreModule))]
    public class AbpjTableDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<AbpjTableDbContext>(null);
        }
    }
}
