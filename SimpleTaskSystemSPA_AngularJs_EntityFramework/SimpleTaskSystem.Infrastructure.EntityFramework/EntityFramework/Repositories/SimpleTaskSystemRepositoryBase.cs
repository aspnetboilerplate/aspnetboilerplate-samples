using Abp.Domain.Entities;
using Abp.Domain.Repositories.EntityFramework;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    public abstract class SimpleTaskSystemRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SimpleTaskSystemDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }

    public abstract class SimpleTaskSystemRepositoryBase<TEntity> : SimpleTaskSystemRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        
    }
}