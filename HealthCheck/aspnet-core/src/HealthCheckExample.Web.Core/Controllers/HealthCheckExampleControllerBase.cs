using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HealthCheckExample.Controllers
{
    public abstract class HealthCheckExampleControllerBase: AbpController
    {
        protected HealthCheckExampleControllerBase()
        {
            LocalizationSourceName = HealthCheckExampleConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
