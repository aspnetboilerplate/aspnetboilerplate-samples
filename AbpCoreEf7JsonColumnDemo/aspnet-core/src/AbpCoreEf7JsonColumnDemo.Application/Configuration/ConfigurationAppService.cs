using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpCoreEf7JsonColumnDemo.Configuration.Dto;

namespace AbpCoreEf7JsonColumnDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpCoreEf7JsonColumnDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
