using System.Threading.Tasks;
using AbpKendoDemo.Configuration.Dto;

namespace AbpKendoDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
