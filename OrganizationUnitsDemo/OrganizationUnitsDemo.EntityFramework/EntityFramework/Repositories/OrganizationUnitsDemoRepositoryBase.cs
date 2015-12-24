using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace OrganizationUnitsDemo.EntityFramework.Repositories
{
    public abstract class OrganizationUnitsDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<OrganizationUnitsDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected OrganizationUnitsDemoRepositoryBase(IDbContextProvider<OrganizationUnitsDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class OrganizationUnitsDemoRepositoryBase<TEntity> : OrganizationUnitsDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected OrganizationUnitsDemoRepositoryBase(IDbContextProvider<OrganizationUnitsDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
