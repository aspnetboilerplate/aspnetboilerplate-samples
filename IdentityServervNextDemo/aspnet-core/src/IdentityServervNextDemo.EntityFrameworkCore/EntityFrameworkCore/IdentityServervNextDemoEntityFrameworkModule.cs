using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4vNext;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using IdentityServervNextDemo.EntityFrameworkCore.Seed;

namespace IdentityServervNextDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(IdentityServervNextDemoCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(AbpZeroCoreIdentityServervNextEntityFrameworkCoreModule))]
    public class IdentityServervNextDemoEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<IdentityServervNextDemoDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        IdentityServervNextDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        IdentityServervNextDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServervNextDemoEntityFrameworkModule).GetAssembly());
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
