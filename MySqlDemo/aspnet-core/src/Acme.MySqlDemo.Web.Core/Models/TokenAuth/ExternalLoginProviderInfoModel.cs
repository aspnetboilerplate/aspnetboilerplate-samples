using Abp.AutoMapper;
using Acme.MySqlDemo.Authentication.External;

namespace Acme.MySqlDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
