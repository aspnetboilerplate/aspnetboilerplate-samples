using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdentityServerDemo.SSO.Authorization.Roles;
using IdentityServerDemo.SSO.Authorization.Users;
using IdentityServerDemo.SSO.MultiTenancy;

namespace IdentityServerDemo.SSO.EntityFrameworkCore
{
    public class SSODbContext : AbpZeroDbContext<Tenant, Role, User, SSODbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public SSODbContext(DbContextOptions<SSODbContext> options)
            : base(options)
        {
        }
    }
}
