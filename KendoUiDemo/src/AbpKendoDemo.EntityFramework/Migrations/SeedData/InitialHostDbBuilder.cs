using AbpKendoDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AbpKendoDemo.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly AbpKendoDemoDbContext _context;

        public InitialHostDbBuilder(AbpKendoDemoDbContext context)
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
