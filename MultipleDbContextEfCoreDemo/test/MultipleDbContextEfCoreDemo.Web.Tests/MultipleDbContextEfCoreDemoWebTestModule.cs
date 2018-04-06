using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.Web.Startup;
namespace MultipleDbContextEfCoreDemo.Web.Tests
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class MultipleDbContextEfCoreDemoWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoWebTestModule).GetAssembly());
        }
    }
}