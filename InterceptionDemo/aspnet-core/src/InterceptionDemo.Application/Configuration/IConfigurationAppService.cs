using System.Threading.Tasks;
using InterceptionDemo.Configuration.Dto;

namespace InterceptionDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
