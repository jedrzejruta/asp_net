using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository) => this.productRepository = productRepository;

        public IActionResult Index()
        {
            return View("List");
        }

								public ViewResult List(string category)
								{
												return View(productRepository.Products.Where(x => x.Category == category));
								}

        public ViewResult GetById(int id)
								{
            return View(productRepository.Products.SingleOrDefault(x => x.Id == id));
								}
								public ViewResult ListAll() => View(productRepository.Products);
				}
}