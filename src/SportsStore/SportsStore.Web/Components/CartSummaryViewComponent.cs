﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Components;

public class CartSummaryViewComponent : ViewComponent
{
	private Cart cart;

	public CartSummaryViewComponent(Cart cartService)
	{
		cart = cartService;
	}

	public IViewComponentResult Invoke()
	{
		return View(cart);
	}
}