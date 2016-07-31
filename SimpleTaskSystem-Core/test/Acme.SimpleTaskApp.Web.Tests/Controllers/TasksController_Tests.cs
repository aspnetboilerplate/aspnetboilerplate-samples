using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace Acme.SimpleTaskApp.Web.Tests.Controllers
{
    public class TasksController_Tests : SimpleTaskAppWebTestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Tasks_By_State()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<TasksController>(nameof(TasksController.Index), new
                    {
                        //state = TaskState.Open
                    }
                )
            );

            //Assert
            response.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
