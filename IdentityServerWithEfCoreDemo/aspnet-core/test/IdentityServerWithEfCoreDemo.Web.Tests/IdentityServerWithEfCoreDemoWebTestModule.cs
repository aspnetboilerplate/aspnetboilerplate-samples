using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityServerWithEfCoreDemo.EntityFrameworkCore;
using IdentityServerWithEfCoreDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace IdentityServerWithEfCoreDemo.Web.Tests
{
    [DependsOn(
        typeof(IdentityServerWithEfCoreDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IdentityServerWithEfCoreDemoWebTestModule : AbpModule
    {
        public IdentityServerWithEfCoreDemoWebTestModule(IdentityServerWithEfCoreDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerWithEfCoreDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IdentityServerWithEfCoreDemoWebMvcModule).Assembly);
        }
    }
}