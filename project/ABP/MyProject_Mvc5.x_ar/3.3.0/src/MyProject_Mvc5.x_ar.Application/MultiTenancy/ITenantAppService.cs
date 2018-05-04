using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject_Mvc5.x_ar.MultiTenancy.Dto;

namespace MyProject_Mvc5.x_ar.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
