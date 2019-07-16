using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Controllers
{
    public abstract class HotelControllerBase: AbpController
    {
        protected HotelControllerBase()
        {
            LocalizationSourceName = HotelConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
