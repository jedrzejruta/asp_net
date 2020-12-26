using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2.Models;

namespace lab2.Controllers
{
				public class ApiController : ControllerBase
				{
								private readonly IProductRepository repo;

								public ApiController(IProductRepository productRepository)
								{
												this.repo = productRepository;
								}

								/// <summary>
								/// Get all products
								/// </summary>
								/// <returns></returns>
								[HttpGet("product")]
								public ActionResult<Product> GetProducts()
								{
												var product = repo.Products.ToList();

												return Ok(product);
								}


								/// <summary>
								/// Get specified product by id
								/// </summary>
								/// <param name="id"></param>
								/// <returns></returns>
								[HttpGet("id")]
								public ActionResult<Product> GetProductByID(int id)
								{
												var product = repo.Products.SingleOrDefault(p => p.Id == id);
												if (product == null)
																return NotFound();

												return Ok(product);
								}


								/// <summary>
								/// Delete element by id
								/// </summary>
								/// <param name="id"></param>
								/// <returns></returns>
								[HttpDelete("id")]
								public ActionResult<Product> Delete(int id)
								{
												repo.DeleteProduct(id);

												return NoContent();
								}


								/// <summary>
								/// Add new product
								/// </summary>
								/// <param name="product"></param>
								/// <returns></returns>
								[HttpPost("product")]
								public ActionResult<Product> AddProduct(Product product)
								{
												repo.SaveProduct(product);

												return CreatedAtAction(actionName: nameof(GetProductByID), routeValues: new { id = product.Id }, value: product);

								}

								/// <summary>
								/// Edit product
								/// </summary>
								/// <param name="product"></param>
								/// <returns></returns>
								[HttpPut("product")]
								public ActionResult EditProduct(Product product)
								{
												if (!ModelState.IsValid)
																return BadRequest();

												if (!repo.Products.Any(p => p.Id == product.Id))
																return NotFound();

												repo.SaveProduct(product);

												return NoContent();
								}
								//TODO: add edit [PUT], serve exceptions
				}
}
