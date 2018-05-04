using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject_Mvc5.x_ar.Configuration.Dto;

namespace MyProject_Mvc5.x_ar.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}