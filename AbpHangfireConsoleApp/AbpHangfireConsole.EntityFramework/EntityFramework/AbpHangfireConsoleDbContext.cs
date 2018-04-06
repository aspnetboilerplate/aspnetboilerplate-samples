using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using AbpHangfireConsole.Core.TableModels;

namespace AbpHangfireConsole.EntityFramework.EntityFramework
{
    public class AbpHangfireConsoleDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Hangfire_ServerModel> HangfireServers { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public AbpHangfireConsoleDbContext()
            : base("Default")
        {
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in HangfireConsoleAppDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpHangfireConsoleDbContext since ABP automatically handles it.
         */
        public AbpHangfireConsoleDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public AbpHangfireConsoleDbContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }

        public AbpHangfireConsoleDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }
    }
}