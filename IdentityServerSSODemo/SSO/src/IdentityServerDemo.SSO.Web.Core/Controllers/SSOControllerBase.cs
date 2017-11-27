using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerDemo.SSO.Controllers
{
    public abstract class SSOControllerBase: AbpController
    {
        protected SSOControllerBase()
        {
            LocalizationSourceName = SSOConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
