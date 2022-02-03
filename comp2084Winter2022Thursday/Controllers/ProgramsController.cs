using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace comp2084Winter2022Thursday.Controllers
{
    public class ProgramsController : Controller
    {
        string[] programNames = { "Computer Studies", "Auto", "Hospitality" };

        // GET: Programs
        public ActionResult Index() //ActinResult = interface
        {
            //return Content("Plain text content");

            ViewBag.ProgramNames = programNames;
            return View();
        }
        public ActionResult Name(string name)
        {
            //return JavaScript("<script>alert('hello world');</script>");
            return Content("The value passed is " + name);
            //return View();
        }

        public ActionResult Study(int year, string programName) {
            ViewBag.Year = year;
            ViewBag.ProgramName = programName;
            return View();
        }


    }
}