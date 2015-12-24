using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using OrganizationUnitsDemo.EntityFramework;

namespace OrganizationUnitsDemo
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(OrganizationUnitsDemoCoreModule))]
    public class OrganizationUnitsDemoDataModule : AbpModule
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
