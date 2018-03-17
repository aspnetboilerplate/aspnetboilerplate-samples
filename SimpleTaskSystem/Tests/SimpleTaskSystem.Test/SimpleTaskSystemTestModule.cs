using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.TestBase;

namespace SimpleTaskSystem.Test
{
    [DependsOn(
        typeof(SimpleTaskSystemDataModule),
        typeof(SimpleTaskSystemApplicationModule),
        typeof(AbpTestBaseModule)
    )]
    public class SimpleTaskSystemTestModule : AbpModule
    {

    }
}
