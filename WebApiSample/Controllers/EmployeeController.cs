using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiSample.Controllers
{
    public class EmployeeController : Controller
    {
        public string GET()
        {
            return " this is simple api method example.";       
        }

        //// GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}