using Abp.Application.Services.Dto;

namespace BackgroundJobAndNotificationsDemo.Sessions.Dto
{
    public class GetCurrentLoginInformationsOutput : EntityDto
    {
        public UserLoginInfoDto User { get; set; }

        public TenantLoginInfoDto Tenant { get; set; }
    }
}