using System.Threading.Tasks;
using Volo.PostgreSqlDemo.Configuration.Dto;

namespace Volo.PostgreSqlDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
