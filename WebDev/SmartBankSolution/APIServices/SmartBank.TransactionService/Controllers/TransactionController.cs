using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.TransactionService.DTOs;
using SmartBank.TransactionService.Services;

[ApiController]
[Route("api/transactions")]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _service;

    public TransactionController(ITransactionService service)
    {
        _service = service;
    }

    // DEPOSIT
    [HttpPost("{accountId}/deposit")]
    public async Task<IActionResult> Deposit(int accountId, [FromBody] TransactionRequestDTO dto)
    {
        var token = Request.Headers["Authorization"]
                        .ToString()
                        .Replace("Bearer ", "");

        var result = await _service.DepositAsync(accountId, dto.Amount, token);

        return Ok(result);
    }

    // WITHDRAW
    [HttpPost("{accountId}/withdraw")]
    public async Task<IActionResult> Withdraw(int accountId, [FromBody] TransactionRequestDTO dto)
    {
        var token = Request.Headers["Authorization"]
                        .ToString()
                        .Replace("Bearer ", "");

        var result = await _service.WithdrawAsync(accountId, dto.Amount, token);

        return Ok(result);
    }

    // GET TRANSACTIONS
    [HttpGet("account/{accountId}")]
    public async Task<IActionResult> GetByAccount(int accountId)
    {
        var result = await _service.GetByAccountIdAsync(accountId);
        return Ok(result);
    }
}