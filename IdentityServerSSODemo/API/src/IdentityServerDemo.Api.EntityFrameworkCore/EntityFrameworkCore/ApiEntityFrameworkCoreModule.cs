using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IdentityServerDemo.Api.EntityFrameworkCore
{
    [DependsOn(
        typeof(ApiCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class ApiEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApiEntityFrameworkCoreModule).GetAssembly());
        }
    }
}