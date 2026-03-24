using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Exceptions;
using SmartBankMiniProject.Helpers;
using SmartBankMiniProject.Models;
using SmartBankMiniProject.Repositories;

namespace SmartBankMiniProject.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
        {
            if (dto.InitialDeposit < 1000)
                throw new BadRequestException("Minimum deposit is 1000");

            var account = _mapper.Map<Account>(dto);
            account.Balance = dto.InitialDeposit;

            var created = await _repo.CreateAsync(account);

            // Generate Account Number AFTER save
            created.AccountNumber = AccountNumberGenerator.Generate(created.Id);
            await _repo.UpdateAsync(created);

            return _mapper.Map<AccountDto>(created);
        }

        public async Task<List<AccountDto>> GetAllAsync()
        {
            var accounts = await _repo.GetAllAsync();
            return _mapper.Map<List<AccountDto>>(accounts);
        }

        public async Task<AccountDto> GetByIdAsync(int id)
        {
            var account = await _repo.GetByIdAsync(id);
            if (account == null)
                throw new NotFoundException("Account not found");

            return _mapper.Map<AccountDto>(account);
        }

        public async Task DepositAsync(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetByIdAsync(dto.AccountId);
            if (account == null)
                throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;
            await _repo.UpdateAsync(account);
        }

        public async Task WithdrawAsync(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetByIdAsync(dto.AccountId);
            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance must be 1000");

            account.Balance -= dto.Amount;
            await _repo.UpdateAsync(account);
        }
    }
}
