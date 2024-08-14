using System.Threading.Tasks;
using MultipleDbContextEfCoreDemo.Configuration.Dto;

namespace MultipleDbContextEfCoreDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
