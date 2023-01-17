using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MassTransitSample.EntityFrameworkCore;
using MassTransitSample.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MassTransitSample.Web.Tests
{
    [DependsOn(
        typeof(MassTransitSampleWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MassTransitSampleWebTestModule : AbpModule
    {
        public MassTransitSampleWebTestModule(MassTransitSampleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MassTransitSampleWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MassTransitSampleWebMvcModule).Assembly);
        }
    }
}