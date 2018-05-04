using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject_Mvc5.x_ar.Authorization.Accounts.Dto;

namespace MyProject_Mvc5.x_ar.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
