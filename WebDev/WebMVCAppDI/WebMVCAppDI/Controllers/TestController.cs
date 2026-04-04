using Microsoft.AspNetCore.Mvc;
using WebMVCAppDI.Services;

namespace WebMVCAppDI.Controllers
{
    public class TestController : Controller
    {
        private IGreet _services { get; set; }
        public TestController(IGreet service)
        {
            _services = service;
        }
        public IActionResult Index()
        {
            ViewBag.greet = _services.SayHello("Test");
            return View();
        }
    }
}
