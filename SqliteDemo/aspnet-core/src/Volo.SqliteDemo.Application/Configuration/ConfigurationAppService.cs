using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Volo.SqliteDemo.Configuration.Dto;

namespace Volo.SqliteDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SqliteDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
