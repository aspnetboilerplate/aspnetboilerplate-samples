using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AbpKendoDemo.EntityFramework.Repositories
{
    public abstract class AbpKendoDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpKendoDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AbpKendoDemoRepositoryBase(IDbContextProvider<AbpKendoDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AbpKendoDemoRepositoryBase<TEntity> : AbpKendoDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AbpKendoDemoRepositoryBase(IDbContextProvider<AbpKendoDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
