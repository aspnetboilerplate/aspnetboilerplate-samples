using Abp.Application.Services.Dto;

namespace MultipleDbContextEfCoreDemo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

