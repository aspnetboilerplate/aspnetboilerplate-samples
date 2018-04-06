using Abp.AutoMapper;
using Volo.PostgreSqlDemo.Authentication.External;

namespace Volo.PostgreSqlDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
