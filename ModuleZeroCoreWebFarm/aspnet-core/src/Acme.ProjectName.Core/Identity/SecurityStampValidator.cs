using Abp.Authorization;
using Acme.ProjectName.Authorization.Roles;
using Acme.ProjectName.Authorization.Users;
using Acme.ProjectName.MultiTenancy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Acme.ProjectName.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock)
            : base(
                options,
                signInManager,
                systemClock)
        {
        }
    }
}