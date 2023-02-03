using Abp.Application.Services.Dto;
using System;

namespace AbpCoreEf7JsonColumnDemo.Users.Dto
{
    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
