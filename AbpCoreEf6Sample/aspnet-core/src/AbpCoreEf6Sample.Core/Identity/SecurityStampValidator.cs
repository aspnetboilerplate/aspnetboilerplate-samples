using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using AbpCoreEf6Sample.Authorization.Roles;
using AbpCoreEf6Sample.Authorization.Users;
using AbpCoreEf6Sample.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace AbpCoreEf6Sample.Identity
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
