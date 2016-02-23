using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using InterceptionDemo.EntityFramework;

namespace InterceptionDemo
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(InterceptionDemoCoreModule))]
    public class InterceptionDemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
