using SmartBank.TransactionService.DTOs;
using SmartBank.TransactionService.Models;
using SmartBank.TransactionService.Repositories;
using SmartBank.TransactionService.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly AccountApiClient _accountApi;

    public TransactionService(ITransactionRepository repository, AccountApiClient accountApi)
    {
        _repository = repository;
        _accountApi = accountApi;
    }

    //public async Task<TransactionDto> DepositAsync(int accountId, decimal amount)
    //{
    //    if (amount <= 0)
    //        throw new Exception("Invalid amount");

    //    bool success = true;

    //    try
    //    {
    //        await _accountApi.DepositAsync(accountId, amount);
    //    }
    //    catch
    //    {
    //        success = false;
    //    }

    //    var transaction = new Transaction
    //    {
    //        AccountId = accountId,
    //        Amount = amount,
    //        Type = "Deposit",
    //        Status = success ? "Success" : "Failed",
    //        CreatedAt = DateTime.UtcNow
    //    };

    //    await _repository.AddAsync(transaction);

    //    return MapToDTO(transaction);
    //}
    public async Task<TransactionDto> DepositAsync(int accountId, decimal amount, string token)
    {
        if (amount <= 0)
            throw new Exception("Invalid amount");

        bool success = true;

        try
        {
            await _accountApi.DepositAsync(accountId, amount, token);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ACCOUNT SERVICE ERROR:");
            Console.WriteLine(ex.Message);

            success = false;
        }

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            Type = "Deposit",
            Status = success ? "Success" : "Failed",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(transaction);

        return MapToDTO(transaction);
    }

    public async Task<TransactionDto> WithdrawAsync(int accountId, decimal amount, string token)
    {
        if (amount <= 0)
            throw new Exception("Invalid amount");

        bool success = true;

        try
        {
            await _accountApi.WithdrawAsync(accountId, amount, token);
        }
        catch
        {
            success = false;
        }

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            Type = "Withdraw",
            Status = success ? "Success" : "Failed",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(transaction);

        return MapToDTO(transaction);
    }

    public async Task<List<TransactionDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(MapToDTO).ToList();
    }

    public async Task<List<TransactionDto>> GetByAccountIdAsync(int accountId)
    {
        var list = await _repository.GetByAccountIdAsync(accountId);
        return list.Select(MapToDTO).ToList();
    }

    private TransactionDto MapToDTO(Transaction t)
    {
        return new TransactionDto
        {
            TransactionId = t.TransactionId,
            AccountId = t.AccountId,
            Amount = t.Amount,
            Type = t.Type,
            Status = t.Status,
            CreatedAt = t.CreatedAt
        };
    }
}