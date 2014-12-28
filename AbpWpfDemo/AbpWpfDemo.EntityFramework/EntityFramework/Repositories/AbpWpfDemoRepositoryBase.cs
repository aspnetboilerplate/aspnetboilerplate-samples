using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AbpWpfDemo.EntityFramework.Repositories
{
    public abstract class AbpWpfDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpWpfDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AbpWpfDemoRepositoryBase(IDbContextProvider<AbpWpfDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    public abstract class AbpWpfDemoRepositoryBase<TEntity> : AbpWpfDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AbpWpfDemoRepositoryBase(IDbContextProvider<AbpWpfDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
