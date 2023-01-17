using System.Threading.Tasks;
using MassTransitSample.Configuration.Dto;

namespace MassTransitSample.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
