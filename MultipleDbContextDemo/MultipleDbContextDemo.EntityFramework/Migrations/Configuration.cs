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
            context.Persons.AddOrUpdate(p => p.PersonName,
                new Person("Yunus"),
                new Person("Emre")
                );
        }
    }
}
