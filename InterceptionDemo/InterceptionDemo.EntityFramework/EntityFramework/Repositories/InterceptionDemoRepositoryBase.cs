using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace InterceptionDemo.EntityFramework.Repositories
{
    public abstract class InterceptionDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<InterceptionDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected InterceptionDemoRepositoryBase(IDbContextProvider<InterceptionDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class InterceptionDemoRepositoryBase<TEntity> : InterceptionDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected InterceptionDemoRepositoryBase(IDbContextProvider<InterceptionDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
