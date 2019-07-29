using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using AbpWcfDemo.Beachs;
using AbpWcfDemo.Events.Dto;

namespace AbpWcfDemo.Events {

    [AbpAllowAnonymous]
    public class EventsAppService
        : WcfAppServiceBaseWithCrud<Event, EventDto, int, PagedAndSortedResultRequestDto, CreateEventDto, UpdateEventDto>, IEventsAppService {
        private readonly IBeachRepository _beachRepository;

        /// <summary>
        ///
        /// </summary>
        public EventsAppService(
            IEventRepository repository,
            IBeachRepository beachRepository)
            : base(repository) {
            _beachRepository = beachRepository;
        }

        /// <summary>
        ///     This is a simple service method
        /// </summary>
        public async Task<EventDto> NextAvailable() {
            var eventz = await Repository.FirstOrDefaultAsync(evt => evt.Id < int.MaxValue);

            if (eventz != null) {
                if (eventz.BeachId > 0) {
                    eventz.Beach = await _beachRepository.FirstOrDefaultAsync(b => b.Id == eventz.BeachId);
                }
                return MapToEntityDto(eventz);
            } else {
                return new EventDto {
                    Id = new Random().Next(int.MaxValue),
                    Title = "Happy hour on the beach",
                    IsActive = true,
                    Start = DateTime.Now.AddDays(1),
                    End = DateTime.Now.AddDays(1).AddHours(4),
                    BeachId = new Random().Next(int.MaxValue),
                    BeachName = "Playa del Carmen"
                };
            }
        }


        public Task<IPagedResult<EventDto>> GetAllActive(GetAllActiveInputDto input) {
            throw new NotImplementedException();
        }
    }

}