using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class TestRepository : ITestRepository
    {
        public IEnumerable<TestModel> GetItems()
        {
            return new List<TestModel>()
            {
                new TestModel
                {
                    TestName = "Produkt",
                    TestDesc = "Opis produktu",
                    TestPrice = 100
                }
            };
        }
    }
}
