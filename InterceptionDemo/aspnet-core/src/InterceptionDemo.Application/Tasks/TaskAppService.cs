using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Json;
using Castle.Core.Logging;
using InterceptionDemo.Tasks.Dto;
using System;

namespace InterceptionDemo.Tasks
{
    public class TaskAppService : ApplicationService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IPermissionChecker _permissionChecker;
        private readonly ILogger _logger;

        public TaskAppService(IRepository<Task> taskRepository,
            IPermissionChecker permissionChecker, ILogger logger)
        {
            _taskRepository = taskRepository;
            _permissionChecker = permissionChecker;
            _logger = logger;
        }

        public void CreateTask(CreateTaskInput input)
        {
            _logger.Debug("Running CreateTask method: " + input.ToJsonString());

            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException("input");
                }

                if (!_permissionChecker.IsGranted("TaskCreationPermission"))
                {
                    throw new Exception("No permission for this operation!");
                }

                _taskRepository.Insert(new Task(input.Title, input.Description, input.AssignedUserId));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }

            _logger.Debug("CreateTask method is successfully completed!");
        }
    }   
}
