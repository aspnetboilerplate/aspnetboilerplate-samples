﻿using System.Linq;
using Abp.Runtime.Validation;
using Shouldly;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks;
using SimpleTaskSystem.Tasks.Dtos;
using Xunit;

namespace SimpleTaskSystem.Test.Tasks
{
    public class TaskAppService_Tests : SimpleTaskSystemTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            //Creating the class which is tested (SUT - Software Under Test)
            _taskAppService = LocalIocManager.Resolve<ITaskAppService>();
        }

        [Fact]
        public void Should_Get_Tasks()
        {
            //Run SUT
            var output = _taskAppService.GetTasks(new GetTasksInput { State = TaskState.Completed });

            //Checking results
            output.Tasks.Count.ShouldBe(2);
            output.Tasks.All(t => t.State == (byte)TaskState.Completed).ShouldBe(true);
        }

        [Fact]
        public void Should_Create_New_Tasks()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Tasks.Count());
            var thomasMore = GetPerson("Thomas More");

            //Run SUT
            _taskAppService.CreateTask(
                new CreateTaskInput
                {
                    Description = "my test task 1"
                });
            _taskAppService.CreateTask(
                new CreateTaskInput
                {
                    Description = "my test task 2",
                    AssignedPersonId = thomasMore.Id
                });

            //Check results
            UsingDbContext(context =>
            {
                context.Tasks.Count().ShouldBe(initialTaskCount + 2);
                context.Tasks.FirstOrDefault(t => t.AssignedPersonId == null && t.Description == "my test task 1").ShouldNotBe(null);
                var task2 = context.Tasks.FirstOrDefault(t => t.Description == "my test task 2");
                task2.ShouldNotBe(null);
                task2.AssignedPersonId.ShouldBe(thomasMore.Id);
            });
        }

        [Fact]
        public void Should_Not_Create_Task_Without_Description()
        {
            //Description is not set
            Assert.Throws<AbpValidationException>(() => _taskAppService.CreateTask(new CreateTaskInput()));
        }

        //Trying to assign a task of Isaac Asimov to Thomas More
        [Fact]
        public void Should_Change_Assigned_People()
        {
            //We can work with repositories instead of DbContext
            var taskRepository = LocalIocManager.Resolve<ITaskRepository>();

            //Obtain test data
            var isaacAsimov = GetPerson("Isaac Asimov");
            var thomasMore = GetPerson("Thomas More");
            var targetTask = taskRepository.FirstOrDefault(t => t.AssignedPersonId == isaacAsimov.Id);
            targetTask.ShouldNotBe(null);

            //Run SUT
            _taskAppService.UpdateTask(
                new UpdateTaskInput
                {
                    TaskId = targetTask.Id,
                    AssignedPersonId = thomasMore.Id
                });

            //Check result
            taskRepository.Get(targetTask.Id).AssignedPersonId.ShouldBe(thomasMore.Id);
        }

        private Person GetPerson(string name)
        {
            return UsingDbContext(context => context.People.Single(p => p.Name == name));
        }
    }
}
