using System.Threading.Tasks;
using Acme.ProjectName.Configuration.Dto;

namespace Acme.ProjectName.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}