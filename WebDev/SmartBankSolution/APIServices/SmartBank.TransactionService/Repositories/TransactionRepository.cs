using Microsoft.EntityFrameworkCore;
using SmartBank.TransactionService.Data;
using SmartBank.TransactionService.Models;
namespace SmartBank.TransactionService.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            var result = await _context.SaveChangesAsync();
            //Console.WriteLine("Rows affected: " + result);
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetByAccountIdAsync(int accountId)
        {
            return await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
    }
}
