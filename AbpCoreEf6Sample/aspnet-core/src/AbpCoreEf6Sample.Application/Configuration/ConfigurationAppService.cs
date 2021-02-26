using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpCoreEf6Sample.Configuration.Dto;

namespace AbpCoreEf6Sample.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpCoreEf6SampleAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
