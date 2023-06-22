namespace SportsStore.Web.Components;

using Microsoft.AspNetCore.Mvc;
using Models;

public class NavigationMenuViewComponent : ViewComponent
{
	private IStoreRepository repository;

	public NavigationMenuViewComponent(IStoreRepository repo)
	{
		repository = repo;
	}

	public IViewComponentResult Invoke()
	{
		return View(repository.Products
			.Select(x => x.Category)
			.Distinct()
			.OrderBy(x => x));
	}
}