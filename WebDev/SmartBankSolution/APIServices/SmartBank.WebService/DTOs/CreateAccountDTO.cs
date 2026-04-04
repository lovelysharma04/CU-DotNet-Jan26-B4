using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.DTOs
{
    public class CreateAccountDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal InitialDeposit { get; set; }
    }
}
