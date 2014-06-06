using Abp.Domain.Entities;
using Abp.Domain.Repositories.EntityFramework;
using SimpleTaskSystem.People;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    public class PersonRepository : SimpleTaskSystemRepositoryBase<Person>, IPersonRepository
    {

    }

    public class SimpleTaskSystemRepositoryBase<TEntity> : SimpleTaskSystemRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        
    }

    public class SimpleTaskSystemRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SimpleTaskSystemDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }
}