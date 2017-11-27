using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IdentityServerDemo.SSO.Configuration.Dto;

namespace IdentityServerDemo.SSO.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SSOAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
