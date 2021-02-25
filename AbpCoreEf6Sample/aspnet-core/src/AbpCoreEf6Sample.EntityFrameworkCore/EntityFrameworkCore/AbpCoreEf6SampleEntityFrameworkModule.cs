using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFramework;
using System.Data.Entity;

namespace AbpCoreEf6Sample.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpCoreEf6SampleCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkModule))]
    public class AbpCoreEf6SampleEntityFrameworkModule : AbpModule
    {
 
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AbpCoreEf6SampleDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf6SampleEntityFrameworkModule).GetAssembly());
        }
    }
}
