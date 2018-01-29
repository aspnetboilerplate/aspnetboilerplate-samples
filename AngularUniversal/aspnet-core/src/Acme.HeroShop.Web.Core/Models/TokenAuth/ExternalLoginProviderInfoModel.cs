using Abp.AutoMapper;
using Acme.HeroShop.Authentication.External;

namespace Acme.HeroShop.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
