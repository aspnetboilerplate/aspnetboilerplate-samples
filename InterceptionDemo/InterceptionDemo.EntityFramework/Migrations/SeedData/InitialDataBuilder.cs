using InterceptionDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace InterceptionDemo.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly InterceptionDemoDbContext _context;

        public InitialDataBuilder(InterceptionDemoDbContext context)
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
