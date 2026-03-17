using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        [Required]
        [RegularExpression("(?i)^(Credit|Debit)$", ErrorMessage = "Only Credit or Debit allowed")]
        public string Category { get; set; }

        public DateTime Date { get; set; }

        [ValidateNever]
        [Display(Name ="Account Holder Name")]
        public int AccountId { get; set; }
        [ValidateNever]
        public Account Account { get; set; }
    }
}
