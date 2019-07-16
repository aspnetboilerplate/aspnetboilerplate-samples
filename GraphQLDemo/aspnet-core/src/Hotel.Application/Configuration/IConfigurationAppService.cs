using System.Threading.Tasks;
using Hotel.Configuration.Dto;

namespace Hotel.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
