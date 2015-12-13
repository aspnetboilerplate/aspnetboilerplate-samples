using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MultipleDbContextDemo.EntityFramework.Repositories
{
    public abstract class MultipleDbContextDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyFirstDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MultipleDbContextDemoRepositoryBase(IDbContextProvider<MyFirstDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MultipleDbContextDemoRepositoryBase<TEntity> : MultipleDbContextDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MultipleDbContextDemoRepositoryBase(IDbContextProvider<MyFirstDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
