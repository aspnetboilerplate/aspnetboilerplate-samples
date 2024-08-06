using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MultipleDbContextEfCoreDemo.Controllers
{
    public abstract class MultipleDbContextEfCoreDemoControllerBase: AbpController
    {
        protected MultipleDbContextEfCoreDemoControllerBase()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
