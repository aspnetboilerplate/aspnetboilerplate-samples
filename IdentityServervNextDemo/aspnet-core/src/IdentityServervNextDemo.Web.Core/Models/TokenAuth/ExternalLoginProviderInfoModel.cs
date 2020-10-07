using Abp.AutoMapper;
using IdentityServervNextDemo.Authentication.External;

namespace IdentityServervNextDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
