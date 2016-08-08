using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace Acme.SimpleTaskApp.Common
{
    public interface ILookupAppService : IApplicationService
    {
        Task<ListResultOutput<ComboboxItemDto>> GetPeopleComboboxItems();
    }
}