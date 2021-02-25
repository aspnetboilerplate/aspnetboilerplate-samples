using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using AbpCoreEf6Sample.EntityFrameworkCore;
using AbpCoreEf6Sample.EntityFrameworkCore.Seed;
using EntityFramework.DynamicFilters;
using System.Data.Entity.Migrations;

namespace AbpCoreEf6Sample
{
    public sealed class AbpCoreEf6SampleDbContextConfiguration : DbMigrationsConfiguration<AbpCoreEf6SampleDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public AbpCoreEf6SampleDbContextConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpCoreEf6Sample";
        }

        protected override void Seed(AbpCoreEf6SampleDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                SeedHelper.SeedHostDb(context);
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
