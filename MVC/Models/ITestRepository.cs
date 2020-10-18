using System.Collections.Generic;

namespace MVC.Models
{
    public interface ITestRepository
    {
        IEnumerable<TestModel> GetItems();
    }
}