using Abp.Localization;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Volo.PostgreSqlDemo.Authorization.Roles;
using Volo.PostgreSqlDemo.Authorization.Users;
using Volo.PostgreSqlDemo.MultiTenancy;

namespace Volo.PostgreSqlDemo.EntityFrameworkCore
{
    public class PostgreSqlDemoDbContext : AbpZeroDbContext<Tenant, Role, User, PostgreSqlDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PostgreSqlDemoDbContext(DbContextOptions<PostgreSqlDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p=>p.Value)
                .HasMaxLength(100);
        }
    }
}
