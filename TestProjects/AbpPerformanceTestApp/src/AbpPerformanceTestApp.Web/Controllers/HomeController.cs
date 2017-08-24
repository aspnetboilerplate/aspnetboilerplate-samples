using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AbpPerformanceTestApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AbpPerformanceTestApp.Web.Controllers
{
    public class HomeController : AbpPerformanceTestAppControllerBase
    {

        private readonly PersonAppService _personService;


        public HomeController(PersonAppService personService)
        {
            _personService = personService;
        }

        public async Task<int> InsertAndGetId(string name, string phoneNumber)
        {
            return await _personService.InsertAndGetId(new InsertAndGetIdInput() { Name = name, PhoneNumber = phoneNumber });
        }

        public async Task Delete(int id)
        {
            await _personService.Delete(new EntityDto() { Id = id });
        }

        public async Task<List<Person>> GetList()
        {
            return await _personService.GetPeople();
        }

        public int GetConstant()
        {
            return _personService.GetConstant();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}