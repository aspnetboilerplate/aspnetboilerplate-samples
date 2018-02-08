using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Volo.SqliteDemo.Controllers
{
    public abstract class SqliteDemoControllerBase: AbpController
    {
        protected SqliteDemoControllerBase()
        {
            LocalizationSourceName = SqliteDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
