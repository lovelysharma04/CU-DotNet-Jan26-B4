using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVCAppDI.Models;
using WebMVCAppDI.Services;

namespace WebMVCAppDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGreet _services { get; set; }

        public HomeController(ILogger<HomeController> logger, IGreet service)
        {
            _logger = logger;
            _services = service;
        }

        public IActionResult Index()
        {
            ViewBag.greet = _services.SayHello("Home");
            return View();
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
