using System.Diagnostics;
using FinTrackPro.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrackPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FinTrackProContext _context;

        public HomeController(ILogger<HomeController> logger, FinTrackProContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new DashboardViewModel();

            vm.TotalAccounts = _context.Account.Count();
            vm.TotalBalance = _context.Account.Sum(a => a.Balance);
            // Use ToLower for case-insensitive comparison so EF Core can translate to SQL
            vm.TotalCredit = _context.Transaction.Where(t => t.Category != null && t.Category.ToLower() == "credit").Sum(t => t.Amount);
            vm.TotalDebit = _context.Transaction.Where(t => t.Category != null && t.Category.ToLower() == "debit").Sum(t => t.Amount);
            vm.RecentTransactions = _context.Transaction.Include(t => t.Account).OrderByDescending(t => t.Date).Take(10).ToList();

            return View(vm);
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
