using AbpWpfDemo.EntityFramework;
using AbpWpfDemo.People;

namespace AbpWpfDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AbpWpfDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpWpfDemo";
        }

        protected override void Seed(AbpWpfDemoDbContext context)
        {
            context.People.AddOrUpdate(
                p => p.Name,
                new Person {Name = "Halil"},
                new Person {Name = "Emre"}
                );
        }
    }
}
