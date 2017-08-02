using System.Threading.Tasks;
using Acme.PhoneBook.Configuration.Dto;

namespace Acme.PhoneBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}