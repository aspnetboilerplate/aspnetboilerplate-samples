using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace PlugInDemo.EntityFramework.Repositories
{
    public abstract class PlugInDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PlugInDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PlugInDemoRepositoryBase(IDbContextProvider<PlugInDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PlugInDemoRepositoryBase<TEntity> : PlugInDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PlugInDemoRepositoryBase(IDbContextProvider<PlugInDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
