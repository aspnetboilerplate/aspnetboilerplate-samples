using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServervNextDemo.EntityFrameworkCore;
using IdentityServervNextDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace IdentityServervNextDemo.Web.Tests
{
    [DependsOn(
        typeof(IdentityServervNextDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IdentityServervNextDemoWebTestModule : AbpModule
    {
        public IdentityServervNextDemoWebTestModule(IdentityServervNextDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServervNextDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IdentityServervNextDemoWebMvcModule).Assembly);
        }
    }
}