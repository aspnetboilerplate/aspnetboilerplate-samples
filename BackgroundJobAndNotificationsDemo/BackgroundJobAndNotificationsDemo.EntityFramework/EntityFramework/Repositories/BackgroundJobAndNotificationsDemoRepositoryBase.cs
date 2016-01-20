using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace BackgroundJobAndNotificationsDemo.EntityFramework.Repositories
{
    public abstract class BackgroundJobAndNotificationsDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<BackgroundJobAndNotificationsDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BackgroundJobAndNotificationsDemoRepositoryBase(IDbContextProvider<BackgroundJobAndNotificationsDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class BackgroundJobAndNotificationsDemoRepositoryBase<TEntity> : BackgroundJobAndNotificationsDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BackgroundJobAndNotificationsDemoRepositoryBase(IDbContextProvider<BackgroundJobAndNotificationsDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
