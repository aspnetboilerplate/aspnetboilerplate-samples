using Abp.Application.Services.Dto;

namespace AbpCoreEf7JsonColumnDemo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

