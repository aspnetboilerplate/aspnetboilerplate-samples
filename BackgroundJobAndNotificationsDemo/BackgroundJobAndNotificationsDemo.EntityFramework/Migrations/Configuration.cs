using System.Data.Entity.Migrations;
using BackgroundJobAndNotificationsDemo.Migrations.SeedData;

namespace BackgroundJobAndNotificationsDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BackgroundJobAndNotificationsDemo.EntityFramework.BackgroundJobAndNotificationsDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BackgroundJobAndNotificationsDemo";
        }

        protected override void Seed(BackgroundJobAndNotificationsDemo.EntityFramework.BackgroundJobAndNotificationsDemoDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
