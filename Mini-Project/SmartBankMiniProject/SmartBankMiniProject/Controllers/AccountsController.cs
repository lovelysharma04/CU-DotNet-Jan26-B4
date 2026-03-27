using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBankMiniProject.Data;
using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Models;
using SmartBankMiniProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBankMiniProject.Controllers
{
    [ApiController]
    [Route("accounts")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            var result = await _service.CreateAccountAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _service.DepositAsync(dto);
            return Ok("Deposit successful");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _service.WithdrawAsync(dto);
            return Ok("Withdrawal successful");
        }
    }
}
