using CorporatePulsePortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CorporatePulsePortal.Controllers
{
    public class EmpsController : Controller
    {
        List<Emp> emps = new List<Emp> 
        {
            new Emp { EmpId = 1, Name = "Amit Sharma", Position = "Software Developer", Salary = 60000 },
            new Emp { EmpId = 2, Name = "Neha Gupta", Position = "QA Engineer", Salary = 50000 },
            new Emp { EmpId = 3, Name = "Rahul Verma", Position = "Project Manager", Salary = 90000 },
            new Emp { EmpId = 4, Name = "Priya Singh", Position = "UI/UX Designer", Salary = 55000 },
            new Emp { EmpId = 5, Name = "Karan Mehta", Position = "Backend Developer", Salary = 65000 },
            new Emp { EmpId = 6, Name = "Anjali Kapoor", Position = "HR Manager", Salary = 70000 },
            new Emp { EmpId = 7, Name = "Rohit Bansal", Position = "DevOps Engineer", Salary = 75000 },
            new Emp { EmpId = 8, Name = "Sneha Arora", Position = "Business Analyst", Salary = 68000 },
            new Emp { EmpId = 9, Name = "Vikas Jain", Position = "Database Administrator", Salary = 72000 },
            new Emp { EmpId = 10, Name = "Pooja Malhotra", Position = "Technical Lead", Salary = 95000 }
        };
        public IActionResult showList()
        {
            ViewBag.emp = emps;
            ViewBag.Announcement = "📢 Office will remain closed tomorrow due to maintenance.";

            ViewData["DepartmentName"] = "Software Development Department";
            ViewData["ServerStatus"] = true;

            return View(emps);  
        }
       

    }
}
