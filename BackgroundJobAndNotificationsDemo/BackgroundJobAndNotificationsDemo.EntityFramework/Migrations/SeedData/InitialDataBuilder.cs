using BackgroundJobAndNotificationsDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace BackgroundJobAndNotificationsDemo.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly BackgroundJobAndNotificationsDemoDbContext _context;

        public InitialDataBuilder(BackgroundJobAndNotificationsDemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
