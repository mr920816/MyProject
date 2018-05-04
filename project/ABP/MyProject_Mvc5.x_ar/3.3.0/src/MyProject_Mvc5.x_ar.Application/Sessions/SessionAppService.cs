using System.Threading.Tasks;
using Abp.Auditing;
using Abp.AutoMapper;
using MyProject_Mvc5.x_ar.Sessions.Dto;

namespace MyProject_Mvc5.x_ar.Sessions
{
    public class SessionAppService : x_arAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput();

            if (AbpSession.UserId.HasValue)
            {
                output.User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>();
            }

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
            }

            return output;
        }
    }
}