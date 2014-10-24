using Abp.Domain.Entities;
using Abp.EntityFramework.Repositories;

namespace AbpjTable.EntityFramework.Repositories
{
    public abstract class AbpjTableRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpjTableDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }

    public abstract class AbpjTableRepositoryBase<TEntity> : AbpjTableRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {

    }
}
