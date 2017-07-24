using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;

namespace MultipleDbContextDemo.Services
{
    public class TestAppService : MultipleDbContextDemoAppServiceBase, ITestAppService
    {
        private readonly IRepository<Person> _personRepository; //in the first db
        private readonly IRepository<Course> _courseRepository; //in the second db

        public TestAppService(IRepository<Person> personRepository, IRepository<Course> courseRepository)
        {
            _personRepository = personRepository;
            _courseRepository = courseRepository;
        }

        public List<string> GetPeople()
        {
            var peopleNames = _personRepository.GetAllList().Select(p => p.PersonName).ToList();
            return peopleNames;
        }

        public List<string> GetCourses()
        {
            var courseNames =  _courseRepository.GetAllList().Select(p => p.CourseName).ToList();
            return courseNames;
        }

        //a sample method uses both databases concurrently
        public List<string> GetPeopleAndCourses()
        {
            List<string> names = new List<string>();

            var peopleNames = _personRepository.GetAllList().Select(p => "Person: " + p.PersonName).ToList();
            names.AddRange(peopleNames);

            var courseNames = _courseRepository.GetAllList().Select(p => "Course: " + p.CourseName).ToList();
            names.AddRange(courseNames);

            return names;
        }

        public void CreatePerson(string name)
        {
	      var entity=    _personRepository.FirstOrDefault(a => a.PersonName == name);
	        if (entity==null)
	        {
				_personRepository.Insert(new Person(name));
			}
	        else
	        {
				throw new UserFriendlyException("Persons already exist");

			}
		}

		public async Task CreateCourseAsync(string name)
		{

			var entity = await _courseRepository.FirstOrDefaultAsync(a => a.CourseName == name);

			if (entity==null)
			{
				await _courseRepository.InsertAsync(new Course(name));

			}
			else
			{
				throw new UserFriendlyException("Courses already exist");


			}


		}
	}
}
