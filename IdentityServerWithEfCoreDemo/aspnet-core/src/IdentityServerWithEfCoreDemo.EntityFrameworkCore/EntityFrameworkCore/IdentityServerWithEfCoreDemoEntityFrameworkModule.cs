using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Configuration.Startup;
using Abp.Zero.EntityFrameworkCore;
using IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer;
using IdentityServerWithEfCoreDemo.EntityFrameworkCore.Seed;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(IdentityServerWithEfCoreDemoCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(AbpZeroCoreIdentityServerEntityFrameworkCoreModule))]
    public class IdentityServerWithEfCoreDemoEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<IdentityServerWithEfCoreDemoDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        IdentityServerWithEfCoreDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        IdentityServerWithEfCoreDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerWithEfCoreDemoEntityFrameworkModule).GetAssembly());
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
