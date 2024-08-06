using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.Authorization.Roles;
using MultipleDbContextEfCoreDemo.Authorization.Users;
using MultipleDbContextEfCoreDemo.MultiTenancy;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public class MultipleDbContextEfCoreDemoDbContext : AbpZeroDbContext<Tenant, Role, User, MultipleDbContextEfCoreDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MultipleDbContextEfCoreDemoDbContext(DbContextOptions<MultipleDbContextEfCoreDemoDbContext> options)
            : base(options)
        {
        }
    }
}
