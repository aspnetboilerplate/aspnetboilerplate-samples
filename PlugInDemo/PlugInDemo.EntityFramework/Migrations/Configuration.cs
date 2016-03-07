using System.Data.Entity.Migrations;
using PlugInDemo.Migrations.SeedData;

namespace PlugInDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PlugInDemo.EntityFramework.PlugInDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlugInDemo";
        }

        protected override void Seed(PlugInDemo.EntityFramework.PlugInDemoDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
