using System.Threading.Tasks;
using System.Web.Mvc;
using AbpWcfDemo.Events;
using AbpWcfDemo.Web.Models;

namespace AbpWcfDemo.Web.Controllers {
    public class HomeController : WcfControllerBase {
        private readonly IEventsAppService _eventsAppService;

        public HomeController(IEventsAppService eventsAppService) {
            _eventsAppService = eventsAppService;
        }

        public async Task<ActionResult> Index() {
            var model = new HomePageVM {
                NextEvent = await _eventsAppService.NextAvailable()
            };
            return View(model);
        }
    }

}