using Abp.AutoMapper;
using MyProject_Mvc5.x_ar.Sessions.Dto;

namespace MyProject_Mvc5.x_ar.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}