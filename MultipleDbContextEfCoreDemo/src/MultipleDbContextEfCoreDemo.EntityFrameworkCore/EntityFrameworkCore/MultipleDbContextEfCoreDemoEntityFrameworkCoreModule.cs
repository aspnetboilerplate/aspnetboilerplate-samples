using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class MultipleDbContextEfCoreDemoEntityFrameworkCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.ReplaceService<IConnectionStringResolver, MyConnectionStringResolver>();

            // Configure first DbContext
            Configuration.Modules.AbpEfCore().AddDbContext<MultipleDbContextEfCoreDemoDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });

            // Configure second DbContext
            Configuration.Modules.AbpEfCore().AddDbContext<MultipleDbContextEfCoreDemoSecondDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    SecondDbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    SecondDbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoEntityFrameworkCoreModule).GetAssembly());
        }
    }
}