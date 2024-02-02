using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using InterceptionDemo.Configuration.Dto;

namespace InterceptionDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : InterceptionDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
