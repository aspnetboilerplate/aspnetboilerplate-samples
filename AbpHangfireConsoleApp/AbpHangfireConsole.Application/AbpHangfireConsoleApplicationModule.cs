using System.Reflection;
using Abp.Modules;
using AbpHangfireConsole.Core;

namespace AbpHangfireConsole.Application
{
    [DependsOn(typeof(AbpHangfireConsoleCoreModule))]
    public class AbpHangfireConsoleApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }}