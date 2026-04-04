using System.ComponentModel.DataAnnotations;

namespace SmartBank.WebService.DTOs
{
    public class DepositWithdrawDTO
    {
        public int AccountId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
    }
}
