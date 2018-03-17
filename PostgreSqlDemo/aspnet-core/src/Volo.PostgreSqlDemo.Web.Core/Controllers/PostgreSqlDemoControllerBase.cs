using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Volo.PostgreSqlDemo.Controllers
{
    public abstract class PostgreSqlDemoControllerBase: AbpController
    {
        protected PostgreSqlDemoControllerBase()
        {
            LocalizationSourceName = PostgreSqlDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
