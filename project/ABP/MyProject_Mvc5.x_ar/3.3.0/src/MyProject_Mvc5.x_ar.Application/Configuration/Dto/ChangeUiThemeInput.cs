using System.ComponentModel.DataAnnotations;

namespace MyProject_Mvc5.x_ar.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [MaxLength(32)]
        public string Theme { get; set; }
    }
}