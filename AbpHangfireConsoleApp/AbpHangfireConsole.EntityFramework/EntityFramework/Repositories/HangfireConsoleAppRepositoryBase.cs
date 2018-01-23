using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AbpHangfireConsole.EntityFramework.EntityFramework.Repositories
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <remarks>TODO: Add common methods for all repositories</remarks>
    public abstract class HangfireConsoleAppRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpHangfireConsoleDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected HangfireConsoleAppRepositoryBase(IDbContextProvider<AbpHangfireConsoleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <remarks>Do not add any methods here. Add to the base class instead.</remarks>
    public abstract class HangfireConsoleAppRepositoryBase<TEntity> : HangfireConsoleAppRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected HangfireConsoleAppRepositoryBase(IDbContextProvider<AbpHangfireConsoleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}