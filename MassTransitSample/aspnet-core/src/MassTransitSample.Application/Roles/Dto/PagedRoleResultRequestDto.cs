using Abp.Application.Services.Dto;

namespace MassTransitSample.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

