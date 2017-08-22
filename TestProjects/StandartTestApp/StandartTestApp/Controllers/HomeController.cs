using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StandartTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonService _personService;

        public HomeController(PersonService personService)
        {
            _personService = personService;
        }

        public async Task<int> InsertAndGetId(string name, string phoneNumber)
        {
            var person = await _personService.InsertAndGetId(new InsertAndGetIdInput() {Name = name, PhoneNumber = phoneNumber });
            return person.Id;
        }

        public async Task Delete(int id)
        {
            await _personService.Delete( new DeletePersonInput {Id = id});
        }

        public async Task<List<PersonDto>> GetList()
        {
            return await _personService.GetAllPeople();
        }

        public int GetConstant()
        {
            return _personService.GetConstant();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
