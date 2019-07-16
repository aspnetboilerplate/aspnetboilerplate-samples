using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Hotel.Configuration.Dto;

namespace Hotel.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : HotelAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
