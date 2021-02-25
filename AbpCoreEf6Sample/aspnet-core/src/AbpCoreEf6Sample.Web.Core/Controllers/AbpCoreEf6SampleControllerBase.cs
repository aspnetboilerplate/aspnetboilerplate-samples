using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpCoreEf6Sample.Controllers
{
    public abstract class AbpCoreEf6SampleControllerBase: AbpController
    {
        protected AbpCoreEf6SampleControllerBase()
        {
            LocalizationSourceName = AbpCoreEf6SampleConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
