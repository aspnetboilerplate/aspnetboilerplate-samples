using Abp.AutoMapper;
using AbpCoreEf6Sample.Authentication.External;

namespace AbpCoreEf6Sample.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
