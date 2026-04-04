using System;

namespace SmartBank.TransactionService.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

        public decimal Amount { get; set; }

        public string? Type { get; set; } // Deposit / Withdraw

        public string? Status { get; set; } // Success / Failed

        public DateTime CreatedAt { get; set; }
    }
}
