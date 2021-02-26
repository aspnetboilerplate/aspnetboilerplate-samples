using System.Threading.Tasks;
using AbpCoreEf6Sample.Configuration.Dto;

namespace AbpCoreEf6Sample.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
