using Abp.AutoMapper;
using Acme.ProjectName.Authentication.External;

namespace Acme.ProjectName.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
