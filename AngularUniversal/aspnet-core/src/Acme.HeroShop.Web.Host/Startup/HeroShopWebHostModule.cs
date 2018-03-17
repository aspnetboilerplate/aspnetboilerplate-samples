using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.HeroShop.Configuration;

namespace Acme.HeroShop.Web.Host.Startup
{
    [DependsOn(
       typeof(HeroShopWebCoreModule))]
    public class HeroShopWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HeroShopWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HeroShopWebHostModule).GetAssembly());
        }
    }
}
