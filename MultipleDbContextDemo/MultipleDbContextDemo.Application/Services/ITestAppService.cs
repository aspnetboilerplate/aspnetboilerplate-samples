using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace MultipleDbContextDemo.Services
{
    public interface ITestAppService : IApplicationService
    {
        List<string> GetPeople();
        
        List<string> GetCourses();
        
        List<string> GetPeopleAndCourses();

        void CreatePerson(string name);

	    Task CreateCourseAsync(string name);



    }
}