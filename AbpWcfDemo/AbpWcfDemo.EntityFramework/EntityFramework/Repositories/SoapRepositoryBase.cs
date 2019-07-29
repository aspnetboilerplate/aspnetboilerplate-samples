using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AbpWcfDemo.EntityFramework.Repositories {

    /// <summary>
    ///     My basic repo class with common repo methods
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class SoapRepositoryBase<TEntity, TPrimaryKey> : 
        EfRepositoryBase<WcfDbContext, TEntity, TPrimaryKey>,
        IWcfRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey> {

        protected SoapRepositoryBase(IDbContextProvider<WcfDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public bool Any(TPrimaryKey id) {
            return GetAll().Any(CreateEqualityExpressionForId(id));
        }

        public Task<bool> AnyAsync(TPrimaryKey id) {
            return Task.FromResult(Any(id));
        }

        public Task<bool> AnyAsync(IQueryable<TEntity> queryable) {
            return queryable.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) {
            return GetAll().AnyAsync(predicate);
        }

        //add common methods for all repositories
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class SoapRepositoryBase<TEntity> : SoapRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SoapRepositoryBase(IDbContextProvider<WcfDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
