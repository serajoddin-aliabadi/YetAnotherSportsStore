﻿namespace SportsStore.Web.Models.ViewModels;

public class LoginModel
{
	public required string Name { get; set; }

	public required string Password { get; set; }

	public string ReturnUrl { get; set; } = "/";
}