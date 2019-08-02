using System.Threading.Tasks;
using HealthCheckExample.Configuration.Dto;

namespace HealthCheckExample.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
