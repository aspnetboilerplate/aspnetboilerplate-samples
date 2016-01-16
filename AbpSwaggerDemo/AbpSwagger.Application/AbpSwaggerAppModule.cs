using System.Reflection;
using Abp.Modules;

namespace AbpSwagger.Application
{
    public class AbpSwaggerAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
