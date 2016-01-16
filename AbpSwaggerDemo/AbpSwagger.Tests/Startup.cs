using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbpSwagger.Tests.Startup))]
namespace AbpSwagger.Tests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
