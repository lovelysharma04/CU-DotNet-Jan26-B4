using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.DTOs;
using WebApplicationMVC.Filters;
using WebApplicationMVC.Services;

namespace WebApplicationMVC.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class AccountController : Controller
    {
        private readonly APIService _api;

        public AccountController(APIService api)
        {
            _api = api;
        }

        // ================= INDEX =================

        public async Task<IActionResult> Index()
        {
            var (success, status, content, accounts) =
                await _api.GetAsync<List<AccountDTO>>(
                    "GatewayClient",
                    "/accounts"   // ✅ FIXED
                );

            if (!success || accounts == null)
            {
                ViewBag.Error = status == 0
                    ? "Gateway unavailable."
                    : content ?? "Failed to load accounts.";

                return View(new List<AccountDTO>());
            }

            // ⚠️ Still N+1 (can improve later)
            foreach (var acc in accounts)
            {
                var (tSuccess, _, _, transactions) =
                    await _api.GetAsync<List<TransactionDTO>>(
                        "GatewayClient",
                        $"/transactions/account/{acc.Id}"   // ✅ FIXED
                    );

                acc.Transactions = transactions ?? new List<TransactionDTO>();
            }

            return View(accounts);
        }

        // ================= CREATE =================

        public IActionResult Create()
        {
            return View(new CreateAccountDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var (success, status, content, data) =
                await _api.PostWithResponseAsync<dynamic>(
                    "GatewayClient",
                    "/accounts",   // ✅ FIXED
                    dto
                );

            if (!success)
            {
                if (status == 0)
                {
                    ModelState.AddModelError("", "Gateway unavailable.");
                    return View(dto);
                }

                if (status == 401)
                {
                    ModelState.AddModelError("", "Unauthorized. Please login.");
                    return View(dto);
                }

                ModelState.AddModelError("", content ?? "Failed to create account.");
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}