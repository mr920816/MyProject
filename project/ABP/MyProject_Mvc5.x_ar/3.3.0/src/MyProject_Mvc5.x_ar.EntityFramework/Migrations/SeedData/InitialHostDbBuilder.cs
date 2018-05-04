using MyProject_Mvc5.x_ar.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MyProject_Mvc5.x_ar.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly x_arDbContext _context;

        public InitialHostDbBuilder(x_arDbContext context)
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
