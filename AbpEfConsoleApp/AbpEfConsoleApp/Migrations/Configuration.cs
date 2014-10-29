using System;

namespace AbpEfConsoleApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyConsoleAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyConsoleAppDbContext context)
        {
            context.Users.AddOrUpdate(
                u => u.Name,
                new User(new Guid("c2ee8f4e-8592-44d5-84c2-ac5fca1752fd"), "Halil"),
                new User(new Guid("b7f88a8e-736e-4708-87d5-beab34f1533b"), "Emre")
                );
        }
    }
}
