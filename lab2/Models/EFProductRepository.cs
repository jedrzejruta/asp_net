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
				}
}
