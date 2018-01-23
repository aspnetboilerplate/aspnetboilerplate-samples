using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using AbpHangfireConsole.Core;
using AbpHangfireConsole.EntityFramework.EntityFramework;

namespace AbpHangfireConsole.EntityFramework
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(AbpHangfireConsoleCoreModule))]
    public class AbpHangfireConsoleEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<AbpHangfireConsoleDbContext>(null);
        }
    }}