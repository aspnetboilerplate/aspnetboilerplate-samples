using Abp.Application.Services.Dto;

namespace IdentityServerWithEfCoreDemo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

