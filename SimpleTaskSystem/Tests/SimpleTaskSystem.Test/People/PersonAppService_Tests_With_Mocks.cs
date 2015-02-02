using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NSubstitute;
using Shouldly;
using SimpleTaskSystem.People;
using Xunit;

namespace SimpleTaskSystem.Test.People
{
    /// <summary>
    /// Alternative test to PersonAppService_Tests
    /// that uses NSubstitute for mocking person repository.
    /// </summary>
    public class PersonAppService_Tests_With_Mocks : SimpleTaskSystemTestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests_With_Mocks()
        {
            //Fake repository will contain 2 people
            var people = new List<Person>
                         {
                             new Person {Name = "John Nash"},
                             new Person {Name = "Forrest Gump"}
                         };

            //Create the fake person repository
            var personRepository = Substitute.For<IRepository<Person>>();

            //Arrange GetAll() method to return the list above
            personRepository.GetAllListAsync().Returns(Task.FromResult(people));

            //Create PersonAppService by providing the fake repository
            _personAppService = new PersonAppService(personRepository);
        }

        [Fact]
        public async Task Should_Get_All_People()
        {
            //Run testing method
            var output = await _personAppService.GetAllPeople();
            
            //Check results
            output.People.Count.ShouldBe(2);
            output.People.FirstOrDefault(p => p.Name == "John Nash").ShouldNotBe(null);
        }
    }
}