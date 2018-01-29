using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Acme.HeroShop.Controllers
{
    public abstract class HeroShopControllerBase: AbpController
    {
        protected HeroShopControllerBase()
        {
            LocalizationSourceName = HeroShopConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
