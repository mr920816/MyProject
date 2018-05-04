using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using MyProject_Mvc5.x_ar.Authorization.Users;
using MyProject_Mvc5.x_ar.MultiTenancy;
using MyProject_Mvc5.x_ar.Users;
using Microsoft.AspNet.Identity;

namespace MyProject_Mvc5.x_ar
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class x_arAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected x_arAppServiceBase()
        {
            LocalizationSourceName = x_arConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}