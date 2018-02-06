using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Acme.MySqlDemo.Authorization.Roles;
using Acme.MySqlDemo.Authorization.Users;
using Acme.MySqlDemo.MultiTenancy;

namespace Acme.MySqlDemo.EntityFrameworkCore
{
    public class MySqlDemoDbContext : AbpZeroDbContext<Tenant, Role, User, MySqlDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MySqlDemoDbContext(DbContextOptions<MySqlDemoDbContext> options)
            : base(options)
        {
        }
    }
}
