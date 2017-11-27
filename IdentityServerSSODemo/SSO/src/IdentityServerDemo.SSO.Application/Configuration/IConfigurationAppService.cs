using System.Threading.Tasks;
using IdentityServerDemo.SSO.Configuration.Dto;

namespace IdentityServerDemo.SSO.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
