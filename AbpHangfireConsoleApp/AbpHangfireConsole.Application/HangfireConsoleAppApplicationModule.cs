using System.Reflection;
using Abp.Modules;
using AbpHangfireConsole.Core;

namespace AbpHangfireConsoleApp
{
    [DependsOn(typeof(AbpHangfireConsoleCoreModule))]
    public class HangfireConsoleAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }}