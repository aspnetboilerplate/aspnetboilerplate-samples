using System.Data.Entity.Migrations;
using OrganizationUnitsDemo.Migrations.SeedData;

namespace OrganizationUnitsDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OrganizationUnitsDemo.EntityFramework.OrganizationUnitsDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OrganizationUnitsDemo";
        }

        protected override void Seed(OrganizationUnitsDemo.EntityFramework.OrganizationUnitsDemoDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
