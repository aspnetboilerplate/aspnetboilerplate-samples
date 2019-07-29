using System.Data.Entity.Migrations;

namespace AbpWcfDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AbpWcfDemo.EntityFramework.WcfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Soap";
        }

        protected override void Seed(AbpWcfDemo.EntityFramework.WcfDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
