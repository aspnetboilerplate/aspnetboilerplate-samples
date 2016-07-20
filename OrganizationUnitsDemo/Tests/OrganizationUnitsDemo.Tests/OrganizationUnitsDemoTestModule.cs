using Abp.Modules;
using Abp.TestBase;

namespace OrganizationUnitsDemo.Tests
{
    [DependsOn(
        typeof(OrganizationUnitsDemoDataModule),
        typeof(AbpTestBaseModule)
        )]
    public class OrganizationUnitsDemoTestModule : AbpModule
    {
        
    }
}