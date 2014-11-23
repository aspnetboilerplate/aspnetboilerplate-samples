using System.Data.Entity;
using Abp.EntityFramework;
using AbpWpfDemo.People;

namespace AbpWpfDemo.EntityFramework
{
    public class AbpWpfDemoDbContext : AbpDbContext
    {
        public virtual IDbSet<Person> People { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public AbpWpfDemoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AbpWpfDemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpWpfDemoDbContext since ABP automatically handles it.
         */
        public AbpWpfDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
