using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;

namespace AbpCoreEf6Sample.EntityFramework
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<AbpCoreEf6SampleDbContext, AbpCoreEf6SampleDbContextConfiguration>
    {
        public AbpZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IIocResolver iocResolver)
            : base(
                unitOfWorkManager,
                connectionStringResolver,
                iocResolver)
        {
        }
    }
}
