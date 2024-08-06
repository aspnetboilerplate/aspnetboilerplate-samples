using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.Reflection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultipleDbContextEfCoreDemo.Configuration;
using MultipleDbContextEfCoreDemo.Migrator;
using System.Transactions;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    public class CustomSecondDbMigrator : ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDbContextResolver _dbContextResolver;
        private readonly IConfigurationRoot _appConfiguration;
        public CustomSecondDbMigrator(
            IDbContextResolver dbContextResolver,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _dbContextResolver = dbContextResolver;
            _unitOfWorkManager = unitOfWorkManager;

            _appConfiguration = AppConfigurations.Get(
               typeof(MultipleDbContextEfCoreDemoMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
        public void CreateOrMigrate()
        {
            var nameOrConnectionString = GetSecondDbConnectionString();

            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                using (var dbContext = _dbContextResolver.Resolve<MultipleDbContextEfCoreDemoSecondDbContext>(nameOrConnectionString, null))
                {
                    dbContext.Database.Migrate();
                    _unitOfWorkManager.Current.SaveChanges();
                    uow.Complete();
                }
            }
        }

        public string GetSecondDbConnectionString()
        {
            return _appConfiguration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.SecondConnectionStringName);
        }
    }
}

