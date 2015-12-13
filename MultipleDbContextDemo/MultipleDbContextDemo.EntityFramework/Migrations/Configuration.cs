using System.Data.Entity.Migrations;

namespace MultipleDbContextDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MultipleDbContextDemo.EntityFramework.MyFirstDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MultipleDbContextDemo";
        }

        protected override void Seed(MultipleDbContextDemo.EntityFramework.MyFirstDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
