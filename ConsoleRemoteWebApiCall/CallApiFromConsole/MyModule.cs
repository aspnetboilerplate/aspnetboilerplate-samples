using System.Reflection;
using Abp.Modules;
using Abp.WebApi;

namespace CallApiFromConsole
{
    [DependsOn(typeof(AbpWebApiModule))]
    public class MyModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}