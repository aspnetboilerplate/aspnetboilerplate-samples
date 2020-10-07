using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IdentityServervNextDemo.Configuration.Dto;

namespace IdentityServervNextDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdentityServervNextDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
