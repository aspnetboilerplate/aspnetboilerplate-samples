using Abp.AutoMapper;
using Volo.SqliteDemo.Authentication.External;

namespace Volo.SqliteDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
