using Microsoft.AspNetCore.Mvc;
using MultipleDbContextEfCoreDemo.Services;
using MultipleDbContextEfCoreDemo.Web.Models;

namespace MultipleDbContextEfCoreDemo.Web.Controllers
{
    public class HomeController : MultipleDbContextEfCoreDemoControllerBase
    {
        private readonly ITestAppService _testAppService;

        public HomeController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }

        public ActionResult Index()
        {
            var data = _testAppService.GetPeopleAndCourses();
            var model = new HomeViewModel
            {
                Data = data
            };

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}