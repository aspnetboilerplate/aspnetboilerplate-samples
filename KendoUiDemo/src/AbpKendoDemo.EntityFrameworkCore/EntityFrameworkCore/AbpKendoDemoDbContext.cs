using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpKendoDemo.Authorization.Roles;
using AbpKendoDemo.Authorization.Users;
using AbpKendoDemo.MultiTenancy;

namespace AbpKendoDemo.EntityFrameworkCore
{
    public class AbpKendoDemoDbContext : AbpZeroDbContext<Tenant, Role, User, AbpKendoDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpKendoDemoDbContext(DbContextOptions<AbpKendoDemoDbContext> options)
            : base(options)
        {
        }
    }
}
