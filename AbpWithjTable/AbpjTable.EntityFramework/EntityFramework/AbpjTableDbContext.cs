using System.Data.Entity;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using AbpjTable.Cities;
using AbpjTable.People;

namespace AbpjTable.EntityFramework
{
    public class AbpjTableDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        public virtual IDbSet<Person> People { get; set; }
        
        public virtual IDbSet<City> Cities { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public AbpjTableDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AbpjTableDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpjTableDbContext since ABP automatically handles it.
         */
        public AbpjTableDbContext(string nameOrConnectionString)
        {

        }
    }
}
