using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpCoreEf7JsonColumnDemo.Controllers
{
    public abstract class AbpCoreEf7JsonColumnDemoControllerBase: AbpController
    {
        protected AbpCoreEf7JsonColumnDemoControllerBase()
        {
            LocalizationSourceName = AbpCoreEf7JsonColumnDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
