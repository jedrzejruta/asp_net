using System.Linq;

namespace lab2.Models
{
				public class EFProductRepository : IProductRepository
				{
								private readonly AppDbContext ctx;

								public EFProductRepository(AppDbContext ctx)
								{
												this.ctx = ctx;
								}

								public IQueryable<Product> Products => ctx.Products;

								public void SaveProduct(Product product)
								{
												if(product.Id == 0)
												{
																ctx.Products.Add(product);
												}
												else
												{
																Product dbEntry = ctx.Products
																				.FirstOrDefault(p => p.Id == product.Id);
																if(dbEntry != null)
																{
																				dbEntry.Name = product.Name;
																				dbEntry.Description = product.Description;
																				dbEntry.Price = product.Price;
																				dbEntry.Category = product.Category;
																}
												}
												ctx.SaveChanges();
								}

								public Product DeleteProduct(int ID)
								{
												Product dbEntry = ctx.Products.FirstOrDefault(p => p.Id == ID);
												if(dbEntry != null)
												{
																ctx.Products.Remove(dbEntry);
																ctx.SaveChanges();
												}
												return dbEntry;
								}
				}
}
