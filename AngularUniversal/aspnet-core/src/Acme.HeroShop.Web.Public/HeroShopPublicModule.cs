using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.HeroShop.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Acme.HeroShop.Web.Public
{
    [DependsOn(typeof(HeroShopWebCoreModule))]
    public class HeroShopPublicModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HeroShopPublicModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HeroShopPublicModule).GetAssembly());
        }
    }
}
