using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace AbpSwagger.Application.Students.Dto
{
    public class PagedAndSortedBaseInputDto
    {
        public string Filter { get; set; }
    }

    public class PagedAndSortedInputDto : PagedAndSortedBaseInputDto, IEntityDto, IPagedResultRequest, ISortedResultRequest
    {
        [Range(1, 1000)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        [Range(0, int.MaxValue)]
        public int PageIndex { get; set; }

        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = 10;
        }

        public int Id { get; set; }
    }
}
