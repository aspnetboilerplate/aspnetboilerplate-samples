using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpPerformanceTestApp
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : EntityDto
    {
        public  string Name { get; set; }

        public  string PhoneNumber { get; set; }
    }
}