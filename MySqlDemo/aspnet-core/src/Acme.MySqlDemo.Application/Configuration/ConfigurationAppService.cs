using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Acme.MySqlDemo.Configuration.Dto;

namespace Acme.MySqlDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MySqlDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
