using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using lab2.Controllers;
using lab2.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace lab2.tests
{
				public class ProductControllerTest
				{

								[Fact]
								public void CanChangeProductPrice()
								{
												//Arrange
												Mock<IProductRepository> mock = new Mock<IProductRepository>();
												mock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product {Id = 1, Price = 100},
												}.AsQueryable<Product>() );

												var controller = new ProductController(mock.Object);
												//Act 
												var result = controller.GetById(1);
												Product product = result.ViewData.Model as Product;
												product.Price = 250;
												//Assert
												Assert.Equal(250, product.Price);
								}

								[Fact]
								public void GetProductByIdTest()
								{
												// Arrange
												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "P1"}, 
																new Product { Id = 2, Name = "P2"},
																new Product { Id = 3, Name = "P3"},
												}.AsQueryable<Product>() );

												var controller = new ProductController(prodRepoMock.Object);
												// Act

												var result = controller.GetById(1);
												Product product = result.ViewData.Model as Product;
												// Assert

												Assert.Equal(expected: "P1", actual: product.Name);
								}

								[Theory]
								[InlineData(1, "P1")]
								[InlineData(2, "P2")]
								public void GetProductsByIds(int id, string expectedName)
								{
												// Arrange
												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "P1"},
																new Product { Id = 2, Name = "P2"},
																new Product { Id = 3, Name = "P3"},
												}.AsQueryable() );

												var controller = new ProductController(prodRepoMock.Object);
												// Act 

												var result = controller.GetById(id);
												Product product = result.ViewData.Model as Product;

												// Assert

												Assert.Equal(expected: expectedName,actual: product.Name);
								}

								[Fact]
								public void CanGetAllProducts()
								{
												// Arrange
												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "P1"},
																new Product { Id = 2, Name = "P2"},
																new Product { Id = 3, Name = "P3"},
												}.AsQueryable());

												var controller = new ProductController(prodRepoMock.Object);
												// Act 

												//var result = controller.ListAll();
												Product[] result = GetViewModel<IEnumerable<Product>>(controller.ListAll()).ToArray();

												//Assert
												Assert.Equal(3, result.Length);
												Assert.Equal("P1", result[0].Name);
								}

								[Fact]
								public void GetProductByCategory()
								{
												// Arrange
												string expectedCategory = "Sporty wodne";
												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "cos", Category = "Sporty wodne"},
																new Product { Id = 2, Name = "ces", Category = "Szachy"},
																new Product { Id = 3, Name = "cas", Category = "Sporty wodne"},
												}.AsQueryable());

												var controller = new ProductController(prodRepoMock.Object);
												// Act
												Product[] products = GetViewModel<IEnumerable<Product>>(controller.List(expectedCategory)).ToArray();


												// Assert
												Assert.Equal(expectedCategory, products[0].Category);

								}

								[Theory]
								[InlineData("cos","Sporty wodne")]
								[InlineData("drr","Szachy")]
								public void GetProductsByCategory(string name,string category)
								{
												// Arrange

												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "cos", Category = "Sporty wodne"},
																new Product { Id = 2, Name = "drr", Category = "Szachy"},
																new Product { Id = 3, Name = "dr4r", Category = "Szachy"},
																new Product { Id = 4, Name = "d2rr", Category = "Szachy"},
																new Product { Id = 5, Name = "coas", Category = "Sporty wodne"},
												}.AsQueryable());

												var controller = new ProductController(prodRepoMock.Object);
												// Act
												Product[] product = GetViewModel<IEnumerable<Product>>(controller.List(category)).ToArray();

												// Assert
												Assert.Equal(name, product[0].Name);
								}

								private T GetViewModel<T>(IActionResult result) where T : class
								{
												return (result as ViewResult)?.ViewData.Model as T;
								}
				}
}
