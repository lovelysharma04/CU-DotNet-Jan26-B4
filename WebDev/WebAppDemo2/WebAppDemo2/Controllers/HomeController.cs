using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppDemo2.Models;

namespace WebAppDemo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowName()
        {
            //data
            string myName = "Lovely";
            ViewBag.Name = myName;

            string city = "Gwalior";
            ViewData["city"] = city;

            int age1 = 23;
            ViewBag.age1 = age1;

            int age2 = 22;
            ViewData["age2"] = age2;

            TempData["salary"] = 20000;
            return View();
        }
        public IActionResult ShowSalary()
        {
            return View();
        }
        public IActionResult ShowSalary2()
        {
            TempData["salary"] = 25000;
            return RedirectToAction("ShowSalary");
        }
        public IActionResult ShowCity()
        {
            string city = "CHD";
            return View(model: city);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
