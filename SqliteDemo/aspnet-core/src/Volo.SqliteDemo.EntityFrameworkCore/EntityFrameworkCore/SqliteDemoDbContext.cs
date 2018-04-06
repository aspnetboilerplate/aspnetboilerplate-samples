using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Volo.SqliteDemo.Authorization.Roles;
using Volo.SqliteDemo.Authorization.Users;
using Volo.SqliteDemo.MultiTenancy;

namespace Volo.SqliteDemo.EntityFrameworkCore
{
    public class SqliteDemoDbContext : AbpZeroDbContext<Tenant, Role, User, SqliteDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SqliteDemoDbContext(DbContextOptions<SqliteDemoDbContext> options)
            : base(options)
        {
        }
    }
}
