using System.Data.Common;
using Abp.Zero.EntityFramework;
using BackgroundJobAndNotificationsDemo.Authorization.Roles;
using BackgroundJobAndNotificationsDemo.MultiTenancy;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.EntityFramework
{
    public class BackgroundJobAndNotificationsDemoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public BackgroundJobAndNotificationsDemoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in BackgroundJobAndNotificationsDemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of BackgroundJobAndNotificationsDemoDbContext since ABP automatically handles it.
         */
        public BackgroundJobAndNotificationsDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public BackgroundJobAndNotificationsDemoDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
