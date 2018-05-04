using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject_Mvc5.x_ar.Roles.Dto;
using MyProject_Mvc5.x_ar.Users.Dto;

namespace MyProject_Mvc5.x_ar.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}