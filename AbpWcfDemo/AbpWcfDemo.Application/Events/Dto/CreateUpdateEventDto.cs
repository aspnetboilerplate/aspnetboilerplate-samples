using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpWcfDemo.Events.Dto {

    [Serializable]
    [AutoMapTo(typeof(Event))]
    public class CreateEventDto {
        // TODO
    }

    [Serializable]
    [AutoMapTo(typeof(Event))]
    public class UpdateEventDto : CreateEventDto, IEntityDto<int> {
        public int Id { get; set; }

        // TODO
    }
}
