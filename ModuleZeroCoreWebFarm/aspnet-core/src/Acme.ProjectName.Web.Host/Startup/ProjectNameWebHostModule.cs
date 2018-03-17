using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.ProjectName.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Acme.ProjectName.Web.Host.Startup
{
    [DependsOn(
       typeof(ProjectNameWebCoreModule))]
    public class ProjectNameWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ProjectNameWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjectNameWebHostModule).GetAssembly());
        }
    }
}
