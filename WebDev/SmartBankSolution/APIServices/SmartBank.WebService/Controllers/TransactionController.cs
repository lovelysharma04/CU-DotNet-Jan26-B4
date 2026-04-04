using Microsoft.AspNetCore.Mvc;
using SmartBank.WebService.DTOs;
using WebApplicationMVC.Filters;
using WebApplicationMVC.Services;

namespace WebApplicationMVC.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class TransactionController : Controller
    {
        private readonly APIService _api;

        public TransactionController(APIService api)
        {
            _api = api;
        }

        // ================= DEPOSIT =================

        [HttpGet]
        public IActionResult Deposit(int accountId)
        {
            return View(new DepositWithdrawDTO
            {
                AccountId = accountId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(DepositWithdrawDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var (success, status, content, data) =
                await _api.PostWithResponseAsync<dynamic>(
                    "GatewayClient",
                    $"/transactions/{dto.AccountId}/deposit",   // CORRECT
                    new { amount = dto.Amount }                // CORRECT
                );

            if (!success)
            {
                TempData["Error"] = GetErrorMessage(status, content);
                return RedirectToAction("Deposit", new { accountId = dto.AccountId });
            }

            TempData["Success"] = "Deposit successful!";
            return RedirectToAction("Index", "Account");
        }

        // ================= WITHDRAW =================

        [HttpGet]
        public IActionResult Withdraw(int accountId)
        {
            return View(new DepositWithdrawDTO
            {
                AccountId = accountId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(DepositWithdrawDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var (success, status, content, data) =
                await _api.PostWithResponseAsync<dynamic>(
                    "GatewayClient",
                    $"/transactions/{dto.AccountId}/withdraw",   // CORRECT
                    new { amount = dto.Amount }
                );

            if (!success)
            {
                TempData["Error"] = GetErrorMessage(status, content);
                return RedirectToAction("Withdraw", new { accountId = dto.AccountId });
            }

            TempData["Success"] = "Withdrawal successful!";
            return RedirectToAction("Index", "Account");
        }

        // ================= ERROR HANDLING =================

        private string GetErrorMessage(int status, string content)
        {
            if (status == 0)
                return "Transaction service unavailable. Try again later.";

            if (status == 401)
                return "Unauthorized. Please login again.";

            return !string.IsNullOrEmpty(content)
                ? content
                : "Transaction failed.";
        }
    }
}