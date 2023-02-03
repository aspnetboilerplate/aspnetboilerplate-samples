using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf7JsonColumnDemo.EntityFrameworkCore;
using AbpCoreEf7JsonColumnDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AbpCoreEf7JsonColumnDemo.Web.Tests
{
    [DependsOn(
        typeof(AbpCoreEf7JsonColumnDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AbpCoreEf7JsonColumnDemoWebTestModule : AbpModule
    {
        public AbpCoreEf7JsonColumnDemoWebTestModule(AbpCoreEf7JsonColumnDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf7JsonColumnDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AbpCoreEf7JsonColumnDemoWebMvcModule).Assembly);
        }
    }
}