using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HealthCheckExample.Configuration.Dto;

namespace HealthCheckExample.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : HealthCheckExampleAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
