using Abp.Application.Services.Dto;

namespace AbpWcfDemo.Events.Dto {

    public class GetAllActiveInputDto : PagedAndSortedResultRequestDto {
        public bool IsActive { get; set; }
        public int? BeachId { get; set; }
    }
}