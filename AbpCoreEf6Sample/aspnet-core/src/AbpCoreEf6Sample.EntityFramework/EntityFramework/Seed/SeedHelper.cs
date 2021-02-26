using AbpCoreEf6Sample.EntityFramework.Seed.Host;
using AbpCoreEf6Sample.EntityFramework.Seed.Tenants;

namespace AbpCoreEf6Sample.EntityFramework.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(AbpCoreEf6SampleDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }
    }
}
