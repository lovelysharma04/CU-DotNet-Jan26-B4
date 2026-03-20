using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day62_LoanManagementSystem.Models;

namespace Day62_LoanManagementSystem.Data
{
    public class Day62_LoanManagementSystemContext : DbContext
    {
        public Day62_LoanManagementSystemContext (DbContextOptions<Day62_LoanManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Day62_LoanManagementSystem.Models.Loan> Loan { get; set; } = default!;
    }
}
