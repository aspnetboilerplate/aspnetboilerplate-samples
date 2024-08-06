using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.Authorization.Roles;
using MultipleDbContextEfCoreDemo.Authorization.Users;
using MultipleDbContextEfCoreDemo.MultiTenancy;
using MultipleDbContextEfCoreDemo.Persons;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    // 1. DbContext
    public class MultipleDbContextEfCoreDemoDbContext : AbpZeroDbContext<Tenant, Role, User, MultipleDbContextEfCoreDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Person> Persons { get; set; }

        public MultipleDbContextEfCoreDemoDbContext(DbContextOptions<MultipleDbContextEfCoreDemoDbContext> options)
            : base(options)
        {
        }
    }
}
