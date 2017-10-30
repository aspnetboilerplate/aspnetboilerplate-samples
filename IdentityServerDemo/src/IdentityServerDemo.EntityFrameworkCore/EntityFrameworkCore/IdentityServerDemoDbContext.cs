using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdentityServerDemo.Authorization.Roles;
using IdentityServerDemo.Authorization.Users;
using IdentityServerDemo.MultiTenancy;

namespace IdentityServerDemo.EntityFrameworkCore
{
    public class IdentityServerDemoDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityServerDemoDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public IdentityServerDemoDbContext(DbContextOptions<IdentityServerDemoDbContext> options)
            : base(options)
        {
        }
    }
}
