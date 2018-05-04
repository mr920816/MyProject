using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyProject_Mvc5.x_ar.MultiTenancy;

namespace MyProject_Mvc5.x_ar.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}