using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Acme.HeroShop.Configuration.Dto;

namespace Acme.HeroShop.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : HeroShopAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
