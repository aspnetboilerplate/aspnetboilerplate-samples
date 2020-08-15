using System.Threading.Tasks;
using IdentityServerWithEfCoreDemo.Configuration.Dto;

namespace IdentityServerWithEfCoreDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
