using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using AbpCoreEf7JsonColumnDemo.Authorization;
using AbpCoreEf7JsonColumnDemo.Authorization.Roles;
using AbpCoreEf7JsonColumnDemo.Authorization.Users;
using AbpCoreEf7JsonColumnDemo.Editions;
using AbpCoreEf7JsonColumnDemo.MultiTenancy;

namespace AbpCoreEf7JsonColumnDemo.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
