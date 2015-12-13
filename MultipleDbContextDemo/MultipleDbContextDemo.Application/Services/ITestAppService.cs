using System.Collections.Generic;
using Abp.Application.Services;

namespace MultipleDbContextDemo.Services
{
    public interface ITestAppService : IApplicationService
    {
        List<string> GetFromFirstDb();
        
        List<string> GetFromSecondDb();
        
        List<string> GetFromBothDbs();
    }
}