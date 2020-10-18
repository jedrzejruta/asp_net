using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository repository;

        public TestController(ITestRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        public IActionResult RedirectToGoogle()
        {
            return Redirect("http://google.com");
        }

        public IActionResult GetJson()
        {
            return Json(new { Name = "Jan", Surname = "Kowalski" });
        }

        public IActionResult TestModel()
        {
            var model = repository.GetItems();
            return View(model);
        }
    }
}
