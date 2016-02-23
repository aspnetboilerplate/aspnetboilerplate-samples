using System.Data.Entity.Migrations;
using InterceptionDemo.Migrations.SeedData;

namespace InterceptionDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InterceptionDemo.EntityFramework.InterceptionDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "InterceptionDemo";
        }

        protected override void Seed(InterceptionDemo.EntityFramework.InterceptionDemoDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
