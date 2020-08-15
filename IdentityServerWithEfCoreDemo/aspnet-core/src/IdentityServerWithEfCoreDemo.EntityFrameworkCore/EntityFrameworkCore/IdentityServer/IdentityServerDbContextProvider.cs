using System;
using System.Linq;
using Abp;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Configuration;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer
{
    public class IdentityServerDbContextProvider : ITransientDependency
    {
        private readonly IIocResolver _iocResolver;
        private readonly IConnectionStringResolver _connectionStringResolver;

        public IdentityServerDbContextProvider(IIocResolver iocResolver, IConnectionStringResolver connectionStringResolver)
        {
            _iocResolver = iocResolver;
            _connectionStringResolver = connectionStringResolver;
        }

        public TDbContext GetDbContext<TDbContext>()
            where TDbContext : DbContext
        {
            var connectionStringResolveArgs = new ConnectionStringResolveArgs(); //MultiTenancySides
            var connectionString = _connectionStringResolver.GetNameOrConnectionString(connectionStringResolveArgs);
            var dbContextType = typeof(TDbContext);

            try
            {
                return _iocResolver.Resolve<TDbContext>(new
                {
                    options = CreateOptions<TDbContext>(connectionString),
                    configurationStoreOptions = IdentityServerStoreOptionsProvider.Instance.ConfigurationStoreOptions,
                    operationalStoreOptions = IdentityServerStoreOptionsProvider.Instance.OperationalStoreOptions
                });
            }
            catch (Castle.MicroKernel.Resolvers.DependencyResolverException ex)
            {
                var hasOptions = HasOptions(dbContextType);
                if (!hasOptions)
                {
                    throw new AggregateException($"The parameter name of {dbContextType.Name}'s constructor must be 'options'", ex);
                }

                throw;
            }

            static bool HasOptions(Type contextType)
            {
                return contextType.GetConstructors().Any(ctor =>
                {
                    var parameters = ctor.GetParameters();
                    return parameters.Length == 1 && parameters.FirstOrDefault()?.Name == "options";
                });
            }
        }
        protected virtual DbContextOptions<TDbContext> CreateOptions<TDbContext>([NotNull] string connectionString)
            where TDbContext : DbContext
        {
            if (_iocResolver.IsRegistered<IAbpDbContextConfigurer<TDbContext>>())
            {
                var configuration = new AbpDbContextConfiguration<TDbContext>(connectionString, null);

                using (var configurer = _iocResolver.ResolveAsDisposable<IAbpDbContextConfigurer<TDbContext>>())
                {
                    configurer.Object.Configure(configuration);
                }

                return configuration.DbContextOptions.Options;
            }

            if (_iocResolver.IsRegistered<DbContextOptions<TDbContext>>())
            {
                return _iocResolver.Resolve<DbContextOptions<TDbContext>>();
            }

            throw new AbpException($"Could not resolve DbContextOptions for {typeof(TDbContext).AssemblyQualifiedName}.");
        }
    }
}
