using System.Data.Entity.Migrations;
using AbpHangfireConsole.EntityFramework.EntityFramework;

namespace AbpHangfireConsole.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AbpHangfireConsoleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpHangfireConsole";
        }

        protected override void Seed(AbpHangfireConsoleDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}