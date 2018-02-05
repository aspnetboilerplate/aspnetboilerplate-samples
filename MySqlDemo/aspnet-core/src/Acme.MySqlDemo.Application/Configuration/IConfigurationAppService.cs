using System.Threading.Tasks;
using Acme.MySqlDemo.Configuration.Dto;

namespace Acme.MySqlDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
