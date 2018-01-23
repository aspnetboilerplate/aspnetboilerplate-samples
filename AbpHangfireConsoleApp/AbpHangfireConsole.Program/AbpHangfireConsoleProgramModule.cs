using System.Reflection;
using Abp.Hangfire;
using Abp.Modules;
using AbpHangfireConsole.Application;
using AbpHangfireConsole.EntityFramework;
using AbpHangfireConsole.Hangfire;

namespace AbpHangfireConsoleApp
{
    [DependsOn(
        typeof(AbpHangfireConsoleEntityFrameworkModule),
        typeof(AbpHangfireConsoleApplicationModule),
        typeof(AbpHangfireModule),
        typeof(AbpHangfireConsoleHangfireModule)
    )]
    public class AbpHangfireConsoleProgramModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}