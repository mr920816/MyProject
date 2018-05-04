using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyProject_Mvc5.x_ar.Configuration.Dto;

namespace MyProject_Mvc5.x_ar.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : x_arAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
