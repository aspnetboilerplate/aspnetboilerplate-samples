using System.Threading.Tasks;
using IdentityServerDemo.Configuration.Dto;

namespace IdentityServerDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}