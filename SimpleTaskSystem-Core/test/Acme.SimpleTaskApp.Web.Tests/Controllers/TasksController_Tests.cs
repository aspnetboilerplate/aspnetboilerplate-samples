using System.Linq;
using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Web.Controllers;
using AngleSharp.Parser.Html;
using Microsoft.EntityFrameworkCore;
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
                        state = TaskState.Open
                    }
                )
            );

            //Assert

            response.ShouldNotBeNullOrWhiteSpace();

            //Get tasks from database
            var tasksInDatabase = await UsingDbContextAsync(async dbContext =>
            {
                return await dbContext.Tasks
                    .Where(t => t.State == TaskState.Open)
                    .ToListAsync();
            });

            //Parse HTML response to check if tasks in the database are returned
            var document = new HtmlParser().Parse(response);
            var listItems = document.QuerySelectorAll("#TaskList li");
            
            //Check task count
            listItems.Length.ShouldBe(tasksInDatabase.Count);

            //Check if returned list items are same those in the database
            foreach (var listItem in listItems)
            {
                var header = listItem.QuerySelector(".list-group-item-heading");
                var taskTitle = header.InnerHtml.Trim();
                tasksInDatabase.Any(t => t.Title == taskTitle).ShouldBeTrue();
            }
        }
    }
}
