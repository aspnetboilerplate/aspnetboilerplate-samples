using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StandartTestApp.Controllers
{
    public class HomeController : Controller
    {
        private  PersonService _personService;


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
            await _personService.Delete( new DeletePersonInput(){Id = id});
        }

        public async Task<List<PersonDto>> GetList()
        {
            var people = await _personService.GetAllPeople();

            return people;
        }

        public int GetConstant()
        {
            var costantNumber = _personService.GetConstant();
            return costantNumber;
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
