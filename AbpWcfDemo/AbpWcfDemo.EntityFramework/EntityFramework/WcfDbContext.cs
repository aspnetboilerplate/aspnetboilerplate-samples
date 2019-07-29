using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using AbpWcfDemo.Beachs;
using AbpWcfDemo.Events;

namespace AbpWcfDemo.EntityFramework
{
    public class WcfDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...
        public virtual IDbSet<Beach> Beachs { get; set; }
        public virtual IDbSet<Event> Events { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public WcfDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WcfDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WcfDbContext since ABP automatically handles it.
         */
        public WcfDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public WcfDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public WcfDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
