using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day62_02_LoanManagementwithDTOs;

namespace Day62_02_LoanManagementwithDTOs.Data
{
    public class Day62_02_LoanManagementwithDTOsContext : DbContext
    {
        public Day62_02_LoanManagementwithDTOsContext (DbContextOptions<Day62_02_LoanManagementwithDTOsContext> options)
            : base(options)
        {
        }

        public DbSet<Day62_02_LoanManagementwithDTOs.Loan> Loan { get; set; } = default!;
    }
}
