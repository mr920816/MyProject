using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;

namespace MyProject_Mvc5.x_ar.Roles.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}