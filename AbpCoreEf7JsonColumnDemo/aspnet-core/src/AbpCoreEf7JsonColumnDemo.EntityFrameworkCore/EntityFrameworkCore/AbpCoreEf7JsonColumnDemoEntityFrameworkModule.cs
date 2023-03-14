using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AbpCoreEf7JsonColumnDemo.EntityFrameworkCore.Seed;

namespace AbpCoreEf7JsonColumnDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpCoreEf7JsonColumnDemoCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AbpCoreEf7JsonColumnDemoEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AbpCoreEf7JsonColumnDemoDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AbpCoreEf7JsonColumnDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AbpCoreEf7JsonColumnDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf7JsonColumnDemoEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
