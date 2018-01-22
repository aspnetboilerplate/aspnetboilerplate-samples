using System.Reflection;
using Abp.Modules;

namespace AbpHangfireConsole.Core
{
    public class AbpHangfireConsoleCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}