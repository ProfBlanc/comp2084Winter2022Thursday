using System.Web;
using System.Web.Mvc;

namespace comp2084Winter2022Thursday
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
