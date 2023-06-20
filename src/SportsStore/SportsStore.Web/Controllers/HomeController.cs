using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Web.Controllers;

public class HomeController : Controller
{

	public IActionResult Index()
		=> View();
}