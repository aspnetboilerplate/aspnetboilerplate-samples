using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpKendoDemo.Configuration.Dto;

namespace AbpKendoDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpKendoDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
