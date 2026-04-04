using System.ComponentModel.DataAnnotations;

namespace WebAppDemo3.Models.ViewModels
{
    public class SumModel
    {
        [Range(1, 100, ErrorMessage = "Range 1-100")]
        [Display(Name = "Number 1")]
        public int Num1 { get; set; }

        [Display(Name = "Number 2")]
        [Range(1, 100, ErrorMessage = "Range 1-100")]
        public int Num2 { get; set; }
        public int Sum { get; set; }
    }
}
