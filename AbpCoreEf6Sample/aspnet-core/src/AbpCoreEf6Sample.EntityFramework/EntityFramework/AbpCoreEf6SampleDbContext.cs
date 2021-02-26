using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using AbpCoreEf6Sample.Authorization.Roles;
using AbpCoreEf6Sample.Authorization.Users;
using AbpCoreEf6Sample.MultiTenancy;

namespace AbpCoreEf6Sample.EntityFramework
{
    public class AbpCoreEf6SampleDbContext : AbpZeroDbContext<Tenant, Role, User, AbpCoreEf6SampleDbContext>
    {
        /* NOTE: 
          *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
          *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
          *   pass connection string name to base classes. ABP works either way.
          */
        public AbpCoreEf6SampleDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AbpCoreEf6SampleDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpCoreEf6SampleDbContext since ABP automatically handles it.
         */
        public AbpCoreEf6SampleDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public AbpCoreEf6SampleDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public AbpCoreEf6SampleDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
