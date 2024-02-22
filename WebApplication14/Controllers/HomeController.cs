using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class HomeController : Controller
    {
        private static int _number;

        public IActionResult Index()
        {
            _number++;

            return View(new CounterViewModel
            {
                Number = _number
            });
        }
    }
}