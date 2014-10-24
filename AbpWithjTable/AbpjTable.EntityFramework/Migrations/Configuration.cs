using AbpjTable.Cities;
using AbpjTable.People;

namespace AbpjTable.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AbpjTable.EntityFramework.AbpjTableDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpjTable";
        }

        protected override void Seed(AbpjTable.EntityFramework.AbpjTableDbContext context)
        {
            context.Cities.AddOrUpdate(
                c => c.Name,
                new City("Adana"),
                new City("New York"),
                new City("Paris"),
                new City("Rome"),
                new City("Motihari"),
                new City("London")
                );

            context.SaveChanges();

            var halil = context.People.FirstOrDefault(p => p.Name == "Halil Ibrahim" && p.Surname == "Kalkan");
            if (halil == null)
            {
                context.People.Add(
                    new Person(
                        "Halil Ibrahim",
                        "Kalkan",
                        context.Cities.Single(c => c.Name == "Adana"),
                        new DateTime(1983, 11, 18))
                    );
            }

            var george = context.People.FirstOrDefault(p => p.Name == "Halil Ibrahim" && p.Surname == "Kalkan");
            if (george == null)
            {
                context.People.Add(
                    new Person(
                        "George",
                        "Orwell",
                        context.Cities.Single(c => c.Name == "Motihari"),
                        new DateTime(1903, 6, 25))
                    );
            }

            context.SaveChanges();
        }
    }
}
