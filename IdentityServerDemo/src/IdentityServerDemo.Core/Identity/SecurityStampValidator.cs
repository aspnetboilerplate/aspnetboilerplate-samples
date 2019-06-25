using Abp.Authorization;
using IdentityServerDemo.Authorization.Roles;
using IdentityServerDemo.Authorization.Users;
using IdentityServerDemo.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;

namespace IdentityServerDemo.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock) 
            :  base(options, signInManager, systemClock)
        {
        }
    }
}