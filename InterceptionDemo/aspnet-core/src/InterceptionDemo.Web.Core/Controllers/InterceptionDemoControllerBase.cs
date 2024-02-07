using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace InterceptionDemo.Controllers
{
    public abstract class InterceptionDemoControllerBase: AbpController
    {
        protected InterceptionDemoControllerBase()
        {
            LocalizationSourceName = InterceptionDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
