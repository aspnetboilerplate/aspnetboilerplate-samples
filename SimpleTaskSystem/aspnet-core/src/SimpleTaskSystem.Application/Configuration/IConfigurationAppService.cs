using System.Threading.Tasks;
using SimpleTaskSystem.Configuration.Dto;

namespace SimpleTaskSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
