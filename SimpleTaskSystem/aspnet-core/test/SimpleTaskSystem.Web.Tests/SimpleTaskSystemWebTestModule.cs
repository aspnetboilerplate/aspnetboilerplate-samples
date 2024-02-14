using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SimpleTaskSystem.EntityFrameworkCore;
using SimpleTaskSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SimpleTaskSystem.Web.Tests
{
    [DependsOn(
        typeof(SimpleTaskSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SimpleTaskSystemWebTestModule : AbpModule
    {
        public SimpleTaskSystemWebTestModule(SimpleTaskSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SimpleTaskSystemWebMvcModule).Assembly);
        }
    }
}