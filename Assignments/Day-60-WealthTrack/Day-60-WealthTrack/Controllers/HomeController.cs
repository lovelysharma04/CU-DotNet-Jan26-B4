using System.Diagnostics;
using Day_60_WealthTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_60_WealthTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Day_60_WealthTrack.Data.Day_60_WealthTrackContext _context;

        public HomeController(ILogger<HomeController> logger, Day_60_WealthTrack.Data.Day_60_WealthTrackContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var investments = _context.Investment.ToList();
            ViewData["TotalCount"] = investments.Count;
            ViewData["TotalPortfolioValue"] = investments.Sum(i => i.PurchasePrice * i.Quantity).ToString("C");
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
