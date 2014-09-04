using Abp.Domain.Repositories;

namespace SimpleTaskSystem.People
{
    /// <summary>
    /// Defines a repository to perform database operations for <see cref="Person"/> Entities.
    /// 
    /// Extends <see cref="IRepository{TEntity}"/> to inherit base repository functionality.
    /// </summary>
    public interface IPersonRepository : IRepository<Person>
    {
        //We can add methods here those are specific to Person entities. Currently, we don't need it, base methods enough.
    }
}
