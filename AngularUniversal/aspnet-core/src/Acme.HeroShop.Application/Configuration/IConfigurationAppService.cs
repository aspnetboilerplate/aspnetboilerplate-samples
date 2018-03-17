using System.Threading.Tasks;
using Acme.HeroShop.Configuration.Dto;

namespace Acme.HeroShop.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
