using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers;

public class HomeController : Controller
{
	private IStoreRepository repository;

	public HomeController(IStoreRepository repo)
	{
		repository = repo;
	}


	public IActionResult Index()
		=> View(repository.Products);
}