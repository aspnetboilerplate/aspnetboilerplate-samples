using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Acme.SimpleTaskApp.Tasks.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Acme.SimpleTaskApp.Tasks
{
    public class TaskAppService : SimpleTaskAppAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ListResultOutput<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .Include(t => t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultOutput<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }

        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _taskRepository.InsertAsync(task);
        }
    }
}
