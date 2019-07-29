using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpWcfDemo.Events.Dto;

namespace AbpWcfDemo.Events {

    /// <summary>
    ///
    /// </summary>
    public interface IEventsAppService : IAsyncCrudAppService<EventDto, int, PagedAndSortedResultRequestDto, CreateEventDto, UpdateEventDto> {

        /// <summary>
        ///     Just for test
        /// </summary>
        Task<EventDto> NextAvailable();

        Task<IPagedResult<EventDto>> GetAllActive(GetAllActiveInputDto input);
    }
}
