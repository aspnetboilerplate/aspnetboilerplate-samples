using System.Threading.Tasks;
using IdentityServervNextDemo.Configuration.Dto;

namespace IdentityServervNextDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
