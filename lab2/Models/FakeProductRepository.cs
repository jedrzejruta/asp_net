using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products =>
            new List<Product>
            {
                new Product { Product_id = 1, Name = "Pomarańcz", Description = "Smaczny", Category = "Soki", Price = 100 },
                new Product { Product_id = 2, Name = "Jabol", Description = "Kwaśny", Category = "Soki", Price = 200 }
            }.AsQueryable<Product>();
    }
}