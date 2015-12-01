using Microsoft.AspNet.Mvc;

namespace RmaManager
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}