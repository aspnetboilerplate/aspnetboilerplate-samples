using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SimpleTaskSystem.Configuration.Dto;

namespace SimpleTaskSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SimpleTaskSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
