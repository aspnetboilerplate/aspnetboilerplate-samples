using Abp.AutoMapper;
using IdentityServerDemo.SSO.Authentication.External;

namespace IdentityServerDemo.SSO.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
