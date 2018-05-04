using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject_Mvc5.x_ar.Sessions.Dto;

namespace MyProject_Mvc5.x_ar.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
