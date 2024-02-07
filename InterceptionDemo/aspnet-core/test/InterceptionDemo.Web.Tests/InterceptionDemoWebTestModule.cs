using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InterceptionDemo.EntityFrameworkCore;
using InterceptionDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace InterceptionDemo.Web.Tests
{
    [DependsOn(
        typeof(InterceptionDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class InterceptionDemoWebTestModule : AbpModule
    {
        public InterceptionDemoWebTestModule(InterceptionDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InterceptionDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(InterceptionDemoWebMvcModule).Assembly);
        }
    }
}