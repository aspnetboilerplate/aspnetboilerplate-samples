using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using OtherApp.Application;

namespace AbpSwagger.Application.WebApi.WebApi
{
    [DependsOn(
        typeof(AbpWebApiModule),
        typeof(AbpSwaggerAppModule),
        typeof(OtherAppModule))]
    public class SwaggerWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(AbpSwaggerAppModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(OtherAppModule).Assembly, "app")
                .Build();
        }
    }
}
