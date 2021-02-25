using Abp.Application.Services.Dto;

namespace AbpCoreEf6Sample.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

