using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using IdentityServerWithEfCoreDemo.Authorization.Roles;
using IdentityServerWithEfCoreDemo.Authorization.Users;
using IdentityServerWithEfCoreDemo.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace IdentityServerWithEfCoreDemo.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
