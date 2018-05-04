using Abp.MultiTenancy;
using MyProject_Mvc5.x_ar.Authorization.Users;

namespace MyProject_Mvc5.x_ar.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}