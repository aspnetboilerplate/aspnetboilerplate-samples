using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.PhoneBook.MultiTenancy;
using Abp.Runtime.Session;
using Abp.IdentityFramework;
using Acme.PhoneBook.Authorization.Users;
using Microsoft.AspNetCore.Identity;

namespace Acme.PhoneBook
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PhoneBookAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected PhoneBookAppServiceBase()
        {
            LocalizationSourceName = PhoneBookConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}