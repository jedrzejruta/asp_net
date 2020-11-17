using lab2.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Components
{
				public class NavigationMenuViewComponent : ViewComponent
				{
								private readonly IProductRepository _repository;
								public NavigationMenuViewComponent(IProductRepository repository)
								{
												this._repository = repository;
								}
								public IViewComponentResult Invoke()
								{
												ViewBag.SelectedCategory = RouteData?.Values["category"];
												return View(_repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
								}
				}
			
}
