using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Acme.ProjectName.Controllers
{
    public abstract class ProjectNameControllerBase: AbpController
    {
        protected ProjectNameControllerBase()
        {
            LocalizationSourceName = ProjectNameConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}