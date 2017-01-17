using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace AbpKendoDemo.Web.Controllers
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