using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IdentityServervNextDemo.Controllers
{
    public abstract class IdentityServervNextDemoControllerBase: AbpController
    {
        protected IdentityServervNextDemoControllerBase()
        {
            LocalizationSourceName = IdentityServervNextDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
