using PlugInDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace PlugInDemo.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PlugInDemoDbContext _context;

        public InitialHostDbBuilder(PlugInDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
