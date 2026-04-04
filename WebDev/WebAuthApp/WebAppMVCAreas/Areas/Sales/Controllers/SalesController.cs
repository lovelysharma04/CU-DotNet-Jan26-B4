using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCAreas.Areas.Sales.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
