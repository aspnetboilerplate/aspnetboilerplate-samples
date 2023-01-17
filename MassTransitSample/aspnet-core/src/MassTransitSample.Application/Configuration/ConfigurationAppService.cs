using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MassTransitSample.Configuration.Dto;

namespace MassTransitSample.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MassTransitSampleAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
