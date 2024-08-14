using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultipleDbContextEfCoreDemo.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MultipleDbContextEfCoreDemo.Web.Tests
{
    [DependsOn(
        typeof(MultipleDbContextEfCoreDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MultipleDbContextEfCoreDemoWebTestModule : AbpModule
    {
        public MultipleDbContextEfCoreDemoWebTestModule(MultipleDbContextEfCoreDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultipleDbContextEfCoreDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MultipleDbContextEfCoreDemoWebMvcModule).Assembly);
        }
    }
}