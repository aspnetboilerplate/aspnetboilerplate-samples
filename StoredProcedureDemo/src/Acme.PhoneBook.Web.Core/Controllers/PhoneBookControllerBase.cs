using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Acme.PhoneBook.Controllers
{
    public abstract class PhoneBookControllerBase: AbpController
    {
        protected PhoneBookControllerBase()
        {
            LocalizationSourceName = PhoneBookConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}