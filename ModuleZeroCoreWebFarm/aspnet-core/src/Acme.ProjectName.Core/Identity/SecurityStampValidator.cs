using Abp.Authorization;
using Acme.ProjectName.Authorization.Roles;
using Acme.ProjectName.Authorization.Users;
using Acme.ProjectName.MultiTenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Acme.ProjectName.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<IdentityOptions> options, 
            SignInManager signInManager) 
            : base(options, signInManager)
        {
        }
    }
}