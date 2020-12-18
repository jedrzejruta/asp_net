using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
				[Authorize]
				public class AdminController : Controller
				{
								private readonly IProductRepository repo;

								public AdminController(IProductRepository productRepository) => repo = productRepository;

								public ViewResult Index() => View(repo.Products);

								public ViewResult Edit(int ID) => View(repo.Products.FirstOrDefault(x => x.Id == ID));

								[HttpPost]
								public IActionResult Save(Product product)
								{
												if (ModelState.IsValid)
												{
																repo.SaveProduct(product);
																TempData["message"] = $"Zapisano {product.Name}";
																return RedirectToAction("Index");
												}
												else

												{
																return View("Edit", product);
												}
								}

								public ActionResult Create() => View("Edit", new Product());

								[HttpPost]
								public ActionResult Delete(int ID)
								{
												Product deletedProduct = repo.DeleteProduct(ID);
												if(deletedProduct != null)
												{
																TempData["mesage"] = $"Usunięto {deletedProduct.Name}";
												}
												return RedirectToAction("Index");
								}


				}
}
