using System;
using Moq;
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
								public void GetProductByCategory()
								{
												// Arrange
												string expectedCategory = "Sporty wodne";
												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "cos", Category = "Sporty wodne"},
												}.AsQueryable());

												var controller = new ProductController(prodRepoMock.Object);
												// Act
												var result = controller.List(expectedCategory);
												Product product = result.ViewData.Model as Product;


												// Assert
												Assert.Equal(expectedCategory, product.Category);

								}

								[Theory]
								[InlineData("cos","Sporty Wodne")]
								[InlineData("drr","Szachy")]
								public void GetProductsByCategory(string name,string category)
								{
												// Arrange

												Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();
												prodRepoMock.Setup(x => x.Products).Returns(new Product[]
												{
																new Product { Id = 1, Name = "cos", Category = "Sporty wodne"},
																new Product { Id = 2, Name = "drr", Category = "Szachy"},
												}.AsQueryable());

												var controller = new ProductController(prodRepoMock.Object);
												// Act
												var result = controller.List(category);
												Product product = result.ViewData.Model as Product;


												// Assert
												Assert.Equal(name, product.Name);

								}

								//private T GetViewModel<T>(IActionResult result) where T : class
								//{
								//				return (result as ViewResult)?.ViewData.Model as T;
								//}


				}
}
