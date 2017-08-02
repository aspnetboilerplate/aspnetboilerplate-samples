using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.PhoneBook.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Acme.PhoneBook.Web.Startup
{
    [DependsOn(typeof(PhoneBookWebCoreModule))]
    public class PhoneBookWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PhoneBookWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<PhoneBookNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhoneBookWebMvcModule).GetAssembly());
        }
    }
}