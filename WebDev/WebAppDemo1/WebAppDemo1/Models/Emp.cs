using System.ComponentModel.DataAnnotations;

namespace WebAppDemo1.Models
{
    public class Emp
    {
        public int EmpId { get; set; }
        [MinLength(4)]
        [Display(Name = "Employee Name")]
        public string EmpName { get; set; }
        [MinLength(4)]
        public string City { get; set; }
        [Range(10000,70000)]
        public int Salary { get; set; }

    }
}
