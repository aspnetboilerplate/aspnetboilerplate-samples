using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpWcfDemo.Events.Dto {

    [Serializable]
    [AutoMapFrom(typeof(Event))]
    public class EventDto : EntityDto<int> {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsActive { get; set; }

        public int BeachId { get; set; }
        public string BeachName { get; set; }
    }
}
