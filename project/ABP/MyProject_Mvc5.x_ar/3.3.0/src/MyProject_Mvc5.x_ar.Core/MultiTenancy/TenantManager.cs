using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using MyProject_Mvc5.x_ar.Authorization.Users;
using MyProject_Mvc5.x_ar.Editions;

namespace MyProject_Mvc5.x_ar.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}