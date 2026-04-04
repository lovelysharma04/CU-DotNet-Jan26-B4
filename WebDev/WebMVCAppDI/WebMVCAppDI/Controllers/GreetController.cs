using Microsoft.AspNetCore.Mvc;
using WebMVCAppDI.Services;

namespace WebMVCAppDI.Controllers
{
    public class GreetController : Controller
    {
        private IGreet _service { get; set; }
        public GreetController(IGreet service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.greet = _service.SayHello("John");
            return View();
        }
    }
}
