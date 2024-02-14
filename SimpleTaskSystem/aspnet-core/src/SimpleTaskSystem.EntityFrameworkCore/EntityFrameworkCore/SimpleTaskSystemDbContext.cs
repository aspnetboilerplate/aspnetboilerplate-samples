using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SimpleTaskSystem.Authorization.Roles;
using SimpleTaskSystem.Authorization.Users;
using SimpleTaskSystem.MultiTenancy;

namespace SimpleTaskSystem.EntityFrameworkCore
{
    public class SimpleTaskSystemDbContext : AbpZeroDbContext<Tenant, Role, User, SimpleTaskSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SimpleTaskSystemDbContext(DbContextOptions<SimpleTaskSystemDbContext> options)
            : base(options)
        {
        }
    }
}
