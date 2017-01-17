using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using AbpKendoDemo.Authorization.Roles;
using AbpKendoDemo.Configuration;
using AbpKendoDemo.MultiTenancy;
using AbpKendoDemo.Users;
using AbpKendoDemo.Web;

namespace AbpKendoDemo.EntityFramework
{
    [DbConfigurationType(typeof(AbpKendoDemoDbConfiguration))]
    public class AbpKendoDemoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        /* Default constructor is needed for EF command line tool. */
        public AbpKendoDemoDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                AbpKendoDemoConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of AbpKendoDemoDbContext since ABP automatically handles it.
         */
        public AbpKendoDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public AbpKendoDemoDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public AbpKendoDemoDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    public class AbpKendoDemoDbConfiguration : DbConfiguration
    {
        public AbpKendoDemoDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
