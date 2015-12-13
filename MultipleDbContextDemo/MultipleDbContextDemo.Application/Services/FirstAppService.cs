using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;

namespace MultipleDbContextDemo.Services
{
    public interface ITestAppService : IApplicationService
    {
        List<string> GetFromFirstDb();
        List<string> GetFromSecondDb();
        List<string> GetFromBothDbs();
    }

    public class TestAppService : MultipleDbContextDemoAppServiceBase, ITestAppService
    {
        private readonly IRepository<Person> _persons;
        private readonly IRepository<Course> _courseRepository;

        public TestAppService(IRepository<Person> persons, IRepository<Course> courseRepository)
        {
            _persons = persons;
            _courseRepository = courseRepository;
        }

        public List<string> GetFromFirstDb()
        {
            var peopleNames = _persons.GetAllList().Select(p => p.PersonName).ToList();
            return peopleNames;
        }

        public List<string> GetFromSecondDb()
        {
            var courseNames =  _courseRepository.GetAllList().Select(p => p.CourseName).ToList();
            return courseNames;
        }

        public List<string> GetFromBothDbs()
        {
            List<string> names = new List<string>();

            var peopleNames = _persons.GetAllList().Select(p => p.PersonName).ToList();
            names.AddRange(peopleNames);

            var courseNames = _courseRepository.GetAllList().Select(p => p.CourseName).ToList();
            names.AddRange(courseNames);

            return names;
        }
    }
}
