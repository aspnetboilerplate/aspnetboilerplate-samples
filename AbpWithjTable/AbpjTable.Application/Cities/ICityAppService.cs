using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace AbpjTable.Cities
{
    public interface ICityAppService : IApplicationService
    {
        ListResultOutput<ComboboxItemDto> GetAllCities();
    }
}
