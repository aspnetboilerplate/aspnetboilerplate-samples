using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleTaskSystem.Web.Controllers
{
    public class HomeController : SimpleTaskSystemControllerBase
    {
        public ActionResult Index()
        { 
            return View();
        }
	}
}