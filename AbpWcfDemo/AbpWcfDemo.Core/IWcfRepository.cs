using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace AbpWcfDemo {

    /// <summary>
    ///     A base repository class for my application.
    ///     Add here common public methods for all our repositories.
    /// </summary>
    public interface IWcfRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey> {

        /// <summary>
        ///     Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        bool Any(TPrimaryKey id);

        /// <summary>
        ///     Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        Task<bool> AnyAsync(TPrimaryKey id);

        /// <summary>
        ///     Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        Task<bool> AnyAsync(IQueryable<TEntity> queryable);

        /// <summary>
        ///     Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    ///     A shortcut of Abp.Domain.Repositories.IRepository`2 for most used primary key type (System.Int32).
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISoapRepository<TEntity> : IWcfRepository<TEntity, int>
        where TEntity : class, IEntity<int> {

        // *** do not add any method here, add to the interface above (since this inherits it)!
    }
}
