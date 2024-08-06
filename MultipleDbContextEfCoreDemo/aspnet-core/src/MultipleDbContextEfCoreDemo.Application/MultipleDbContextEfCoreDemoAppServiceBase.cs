using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using MultipleDbContextEfCoreDemo.Authorization.Users;
using MultipleDbContextEfCoreDemo.MultiTenancy;

namespace MultipleDbContextEfCoreDemo
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MultipleDbContextEfCoreDemoAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected MultipleDbContextEfCoreDemoAppServiceBase()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
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
