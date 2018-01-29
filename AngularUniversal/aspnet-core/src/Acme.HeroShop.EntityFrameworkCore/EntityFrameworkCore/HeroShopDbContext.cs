using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Acme.HeroShop.Authorization.Roles;
using Acme.HeroShop.Authorization.Users;
using Acme.HeroShop.MultiTenancy;

namespace Acme.HeroShop.EntityFrameworkCore
{
    public class HeroShopDbContext : AbpZeroDbContext<Tenant, Role, User, HeroShopDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public HeroShopDbContext(DbContextOptions<HeroShopDbContext> options)
            : base(options)
        {
        }
    }
}
