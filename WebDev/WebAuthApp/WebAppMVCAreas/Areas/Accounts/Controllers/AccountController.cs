using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCAreas.Areas.Accounts.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
