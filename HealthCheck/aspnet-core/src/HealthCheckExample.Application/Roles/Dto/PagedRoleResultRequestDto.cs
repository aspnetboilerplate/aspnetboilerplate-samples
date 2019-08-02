using Abp.Application.Services.Dto;

namespace HealthCheckExample.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

