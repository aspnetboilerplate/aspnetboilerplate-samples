using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MultipleDbContextEfCoreDemo.Configuration.Dto;

namespace MultipleDbContextEfCoreDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MultipleDbContextEfCoreDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
