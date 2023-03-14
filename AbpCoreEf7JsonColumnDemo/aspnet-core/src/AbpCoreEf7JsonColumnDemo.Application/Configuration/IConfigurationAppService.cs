using System.Threading.Tasks;
using AbpCoreEf7JsonColumnDemo.Configuration.Dto;

namespace AbpCoreEf7JsonColumnDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
