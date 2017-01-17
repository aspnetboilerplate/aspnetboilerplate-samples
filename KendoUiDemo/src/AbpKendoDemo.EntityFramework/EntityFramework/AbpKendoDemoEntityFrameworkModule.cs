using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace AbpKendoDemo.EntityFramework
{
    [DependsOn(
        typeof(AbpKendoDemoCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class AbpKendoDemoEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AbpKendoDemoDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}