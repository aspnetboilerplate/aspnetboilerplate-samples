using Abp.Zero.EntityFrameworkCore;
using IdentityServerDemo.Authorization.Roles;
using IdentityServerDemo.Authorization.Users;
using IdentityServerDemo.MultiTenancy;
using Microsoft.EntityFrameworkCore;

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
