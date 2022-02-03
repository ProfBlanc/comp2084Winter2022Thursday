using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace comp2084Winter2022Thursday.Controllers
{
	public class HomeController : Controller
	{
		//URL: nothing: Home/Index
		//URL: Cart => Cart/Index => 404
		//URL Cart/Today => Cart Controoler Today method

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Terms() {

			ViewBag.PageTitle = "Terms & Condtions";
			ViewBag.Content = "You will never fully read all of this and we will hold you to it";

			return View();
		}
	}
}