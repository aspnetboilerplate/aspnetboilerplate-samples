using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using InterceptionDemo.Authorization.Roles;
using InterceptionDemo.Authorization.Users;
using InterceptionDemo.MultiTenancy;

namespace InterceptionDemo.EntityFrameworkCore
{
    public class InterceptionDemoDbContext : AbpZeroDbContext<Tenant, Role, User, InterceptionDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public InterceptionDemoDbContext(DbContextOptions<InterceptionDemoDbContext> options)
            : base(options)
        {
        }
    }
}
