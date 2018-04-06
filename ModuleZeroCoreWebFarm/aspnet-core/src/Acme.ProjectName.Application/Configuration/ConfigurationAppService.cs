using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Acme.ProjectName.Configuration.Dto;

namespace Acme.ProjectName.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ProjectNameAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
