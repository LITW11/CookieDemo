using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class CookieDemoController : Controller
    {
        public IActionResult Index()
        {
            var requestCookieValue = Request.Cookies["last-visit"];
            bool hasBeenHere = requestCookieValue != null;

            var vm = new CookieDemoViewModel
            {
                HasBeenHere = hasBeenHere
            };

            if(hasBeenHere)
            {
                vm.LastVisit = DateTime.Parse(requestCookieValue);
            }

            Response.Cookies.Append("last-visit", DateTime.Now.ToString());

            return View(vm);
        }

        public IActionResult Counter()
        {
            var cookieValue = Request.Cookies["number"];

            int number = 1;
            if(cookieValue != null)
            {
                number = int.Parse(cookieValue);
            }

            //Response.Cookies.Append("number", $"{number + 1}", new CookieOptions
            //{
            //    Expires = new DateTimeOffset(DateTime.Today.AddDays(7))
            //});

            Response.Cookies.Append("number", $"{number + 1}");

            return View(new CounterViewModel
            {
                Number = number
            });
        }
    }
}
