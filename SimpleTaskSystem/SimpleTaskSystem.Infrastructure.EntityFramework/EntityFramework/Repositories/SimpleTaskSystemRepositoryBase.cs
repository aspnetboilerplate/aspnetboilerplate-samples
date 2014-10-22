using Abp.Domain.Entities;
using Abp.EntityFramework.Repositories;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    /// <summary>
    /// We declare a base repository class for our application.
    /// It inherits from <see cref="EfRepositoryBase{TDbContext,TEntity,TPrimaryKey}"/>.
    /// We can add here common methods for all our repositories.
    /// </summary>
    public abstract class SimpleTaskSystemRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SimpleTaskSystemDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }

    /// <summary>
    /// A shortcut of <see cref="SimpleTaskSystemRepositoryBase{TEntity,TPrimaryKey}"/> for Entities with primary key type <see cref="int"/>.
    /// </summary>
    public abstract class SimpleTaskSystemRepositoryBase<TEntity> : SimpleTaskSystemRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {

    }
}
