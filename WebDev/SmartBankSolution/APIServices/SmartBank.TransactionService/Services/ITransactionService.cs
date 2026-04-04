using SmartBank.TransactionService.DTOs;

namespace SmartBank.TransactionService.Services
{
    public interface ITransactionService
    {
        Task<TransactionDto> DepositAsync(int accountId, decimal amount, string token);
        Task<TransactionDto> WithdrawAsync(int accountId, decimal amount, string token);
        Task<List<TransactionDto>> GetAllAsync();
        Task<List<TransactionDto>> GetByAccountIdAsync(int accountId);
    }
}