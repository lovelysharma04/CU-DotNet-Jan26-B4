using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day62_02_LoanManagementwithDTOs.Data;
using Day62_02_LoanManagementwithDTOs.DTOs;

namespace Day62_02_LoanManagementwithDTOs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly Day62_02_LoanManagementwithDTOsContext _context;

        public LoansController(Day62_02_LoanManagementwithDTOsContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoan()
        {
            var loans = await _context.Loan.ToListAsync();

            var result = loans.Select(l => new LoanReadDto
            {
                Id = l.Id,
                BorrowerName = l.BorrowerName,
                Amount = l.Amount,
                LoanTermMonths = l.LoanTermMonths,
                IsApproved = l.IsApproved
            });

            return Ok(result);
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanReadDto>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            var result = new LoanReadDto
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return Ok(result);
        }

        // POST: api/Loans
        [HttpPost]
        public async Task<ActionResult<LoanReadDto>> PostLoan(LoanCreateDto dto)
        {
            var loan = new Loan
            {
                BorrowerName = dto.BorrowerName,
                Amount = dto.Amount,
                LoanTermMonths = dto.LoanTermMonths,
                IsApproved = false
            };

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            var result = new LoanReadDto
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, result);
        }

        // PUT: api/Loans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, LoanUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            loan.BorrowerName = dto.BorrowerName;
            loan.Amount = dto.Amount;
            loan.LoanTermMonths = dto.LoanTermMonths;
            loan.IsApproved = dto.IsApproved;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}