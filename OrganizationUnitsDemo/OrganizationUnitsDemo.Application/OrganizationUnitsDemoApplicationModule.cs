using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace OrganizationUnitsDemo
{
    [DependsOn(typeof(OrganizationUnitsDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class OrganizationUnitsDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
