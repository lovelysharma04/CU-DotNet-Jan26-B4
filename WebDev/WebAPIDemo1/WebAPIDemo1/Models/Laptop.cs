using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo1.Models
{
    public class Laptop
    {
        public int LaptopId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
