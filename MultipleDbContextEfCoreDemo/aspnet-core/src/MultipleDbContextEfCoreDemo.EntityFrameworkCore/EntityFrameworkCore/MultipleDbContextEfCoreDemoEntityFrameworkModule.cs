using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.EntityFrameworkCore.Seed;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class MultipleDbContextEfCoreDemoEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<MultipleDbContextEfCoreDemoDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        MultipleDbContextEfCoreDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        MultipleDbContextEfCoreDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoEntityFrameworkModule).GetAssembly());
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
