using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IdentityServerWithEfCoreDemo.Configuration.Dto;

namespace IdentityServerWithEfCoreDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdentityServerWithEfCoreDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
