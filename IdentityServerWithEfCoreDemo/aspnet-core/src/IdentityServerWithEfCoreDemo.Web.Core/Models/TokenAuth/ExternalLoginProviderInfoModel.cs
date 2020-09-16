using Abp.AutoMapper;
using IdentityServerWithEfCoreDemo.Authentication.External;

namespace IdentityServerWithEfCoreDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
