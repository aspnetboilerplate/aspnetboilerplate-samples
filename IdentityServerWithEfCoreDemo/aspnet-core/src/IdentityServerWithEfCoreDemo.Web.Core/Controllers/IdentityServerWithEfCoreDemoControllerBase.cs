using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerWithEfCoreDemo.Controllers
{
    public abstract class IdentityServerWithEfCoreDemoControllerBase: AbpController
    {
        protected IdentityServerWithEfCoreDemoControllerBase()
        {
            LocalizationSourceName = IdentityServerWithEfCoreDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
