using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace comp2084Winter2022Thursday
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				
				name: "SemesterTerm",
				url: "Semesters/{year}/{term}",
				defaults: new {
				controller = "Semesters",
				action = "Term",
				year = UrlParameter.Optional
				},
				constraints: new { 
					year = @"\d{4}",
					term = @"winter|summer|spring|fall"
				}

				);

			routes.MapRoute(
			name: "ProgramStudy",
			url: "Programs/{year}/{programName}",
			defaults: new
			{
				controller = "Programs",
				action = "Study",
				year = 2022,
//				programName = "Computer Studies"
				programName = UrlParameter.Optional
			},
			constraints: new { year = @"\d{4}" }
			);

			routes.MapRoute(
			name: "ProgramNames",
			url: "Programs/Name/{name}",
			defaults: new { controller = "Programs", action = "Name" }
			);



			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);


		}
	}
}
