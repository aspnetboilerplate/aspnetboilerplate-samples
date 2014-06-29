using Abp.Application.Services;
using SimpleTaskSystem.Tasks.Dtos;

namespace SimpleTaskSystem.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        GetTasksOutput GetTasks(GetTasksInput input);
        void UpdateTask(UpdateTaskInput input);
        void CreateTask(CreateTaskInput input);
    }
}
