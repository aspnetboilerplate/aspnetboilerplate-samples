using Abp.Application.Services.Dto;

namespace AbpjTable.People.Dto
{
    public class GetPeopleInput : IPagedResultRequest
    {
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }
    }
}