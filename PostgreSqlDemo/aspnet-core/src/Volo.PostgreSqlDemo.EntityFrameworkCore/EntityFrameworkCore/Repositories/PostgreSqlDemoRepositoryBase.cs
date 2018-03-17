using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Volo.PostgreSqlDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class PostgreSqlDemoRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<PostgreSqlDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PostgreSqlDemoRepositoryBase(IDbContextProvider<PostgreSqlDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="PostgreSqlDemoRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class PostgreSqlDemoRepositoryBase<TEntity> : PostgreSqlDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PostgreSqlDemoRepositoryBase(IDbContextProvider<PostgreSqlDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
