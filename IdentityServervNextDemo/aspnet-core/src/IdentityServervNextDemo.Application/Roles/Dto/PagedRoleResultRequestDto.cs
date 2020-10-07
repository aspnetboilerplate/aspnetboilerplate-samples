using Abp.Application.Services.Dto;

namespace IdentityServervNextDemo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

