using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MassTransitSample.Controllers
{
    public abstract class MassTransitSampleControllerBase: AbpController
    {
        protected MassTransitSampleControllerBase()
        {
            LocalizationSourceName = MassTransitSampleConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
