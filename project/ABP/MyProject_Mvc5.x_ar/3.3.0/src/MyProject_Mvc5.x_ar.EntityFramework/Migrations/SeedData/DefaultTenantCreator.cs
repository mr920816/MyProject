using System.Linq;
using MyProject_Mvc5.x_ar.EntityFramework;
using MyProject_Mvc5.x_ar.MultiTenancy;

namespace MyProject_Mvc5.x_ar.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly x_arDbContext _context;

        public DefaultTenantCreator(x_arDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
