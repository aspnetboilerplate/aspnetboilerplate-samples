using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IdentityServerDemo.Configuration.Dto;

namespace IdentityServerDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdentityServerDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
