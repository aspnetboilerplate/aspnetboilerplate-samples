using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer
{
    public class IdentityServerDbContextProvider : ITransientDependency
    {
        private readonly IDbContextResolver _dbContextResolver;
        private readonly IConnectionStringResolver _connectionStringResolver;

        public IdentityServerDbContextProvider(IDbContextResolver dbContextResolver,
            IConnectionStringResolver connectionStringResolver)
        {
            _dbContextResolver = dbContextResolver;
            _connectionStringResolver = connectionStringResolver;
        }

        public TDbContext GetDbContext<TDbContext>()
            where TDbContext : DbContext
        {
            var connectionStringResolveArgs = new ConnectionStringResolveArgs() //MultiTenancySides
            {
                ["DbContextType"] = typeof(TDbContext)
            };
            var connectionString = _connectionStringResolver.GetNameOrConnectionString(connectionStringResolveArgs);
            return _dbContextResolver.Resolve<TDbContext>(connectionString, null);
        }
    }
}
