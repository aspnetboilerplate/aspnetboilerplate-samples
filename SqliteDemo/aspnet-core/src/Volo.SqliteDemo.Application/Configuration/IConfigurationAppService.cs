using System.Threading.Tasks;
using Volo.SqliteDemo.Configuration.Dto;

namespace Volo.SqliteDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
