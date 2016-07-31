using System.Threading.Tasks;
using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Tasks.Dtos;
using Acme.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Acme.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };
            return View(model);
        }
    }
}
