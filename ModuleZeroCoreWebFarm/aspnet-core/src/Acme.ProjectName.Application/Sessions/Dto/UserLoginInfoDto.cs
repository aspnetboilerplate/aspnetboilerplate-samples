using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Acme.ProjectName.Authorization.Users;
using Acme.ProjectName.Users;

namespace Acme.ProjectName.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
