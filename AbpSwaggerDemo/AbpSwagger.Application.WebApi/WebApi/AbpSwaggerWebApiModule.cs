using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace AbpSwagger.Application.WebApi.WebApi
{
    [DependsOn(typeof(AbpWebApiModule),
        typeof(AbpSwaggerAppModule))]
    public class SwaggerWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(AbpSwaggerAppModule).Assembly, "app")
                .WithConventionalVerbs()
                .Build();
        }
    }
}
