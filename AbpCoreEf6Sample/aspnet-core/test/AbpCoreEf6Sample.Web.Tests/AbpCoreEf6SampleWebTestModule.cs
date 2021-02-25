using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreEf6Sample.EntityFrameworkCore;
using AbpCoreEf6Sample.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AbpCoreEf6Sample.Web.Tests
{
    [DependsOn(
        typeof(AbpCoreEf6SampleWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AbpCoreEf6SampleWebTestModule : AbpModule
    {
        public AbpCoreEf6SampleWebTestModule(AbpCoreEf6SampleEntityFrameworkModule abpCoreEf6SampleEntityFrameworkModule)
        {
            abpCoreEf6SampleEntityFrameworkModule.SkipSetInitializer = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf6SampleWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AbpCoreEf6SampleWebMvcModule).Assembly);
        }
    }
}