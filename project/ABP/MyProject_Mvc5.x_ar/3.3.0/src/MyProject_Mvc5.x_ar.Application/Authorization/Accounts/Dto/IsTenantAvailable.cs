using System.ComponentModel.DataAnnotations;
using Abp.MultiTenancy;

namespace MyProject_Mvc5.x_ar.Authorization.Accounts.Dto
{
    public class IsTenantAvailableInput
    {
        [Required]
        [MaxLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }
    }
}
