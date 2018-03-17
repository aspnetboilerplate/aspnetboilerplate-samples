using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpKendoDemo.Controllers
{
    public abstract class AbpKendoDemoControllerBase: AbpController
    {
        protected AbpKendoDemoControllerBase()
        {
            LocalizationSourceName = AbpKendoDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
