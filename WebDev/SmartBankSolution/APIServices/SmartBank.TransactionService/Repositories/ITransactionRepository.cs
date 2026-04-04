using SmartBank.TransactionService.Models;

namespace SmartBank.TransactionService.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<List<Transaction>> GetAllAsync();
        Task<List<Transaction>> GetByAccountIdAsync(int accountId);
    }
}
