using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Role { get; set; } = "Customer";
    }
}
