using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Volo.PostgreSqlDemo.Configuration.Dto;

namespace Volo.PostgreSqlDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PostgreSqlDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
