using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Acme.MySqlDemo.Controllers
{
    public abstract class MySqlDemoControllerBase: AbpController
    {
        protected MySqlDemoControllerBase()
        {
            LocalizationSourceName = MySqlDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
