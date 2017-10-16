using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerDemo.Controllers
{
    public abstract class IdentityServerDemoControllerBase: AbpController
    {
        protected IdentityServerDemoControllerBase()
        {
            LocalizationSourceName = IdentityServerDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
