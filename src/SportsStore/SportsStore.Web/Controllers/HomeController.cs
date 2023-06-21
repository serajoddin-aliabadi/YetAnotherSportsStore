using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;
using SportsStore.Web.Models.ViewModels;

namespace SportsStore.Web.Controllers;

public class HomeController : Controller
{
	private IStoreRepository repository;

	public HomeController(IStoreRepository repo)
	{
		repository = repo;
	}

	public int PageSize = 4;


	public ViewResult Index(int productPage = 1)
	{
		return View(new ProductsListViewModel
		{
			Products = repository.Products
					   .OrderBy(p => p.ProductID)
					   .Skip((productPage - 1) * PageSize)
					   .Take(PageSize),
			PagingInfo = new PagingInfo
			{
				CurrentPage = productPage,
				ItemsPerPage = PageSize,
				TotalItems = repository.Products.Count()
			}
		});
	}
}