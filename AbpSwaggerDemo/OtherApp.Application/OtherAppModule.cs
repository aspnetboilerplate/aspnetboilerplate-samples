using System.Reflection;
using Abp.Modules;

namespace OtherApp.Application
{
    public class OtherAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
