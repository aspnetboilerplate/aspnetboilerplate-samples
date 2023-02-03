using Abp.AutoMapper;
using AbpCoreEf7JsonColumnDemo.Authentication.External;

namespace AbpCoreEf7JsonColumnDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
