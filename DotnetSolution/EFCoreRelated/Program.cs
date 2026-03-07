using EFCoreRelated.Data;
using EFCoreRelated.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelated
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Related EF!");

            using(ProjectContext context = new ProjectContext())
            {
                //context.Departments.Add(
                //    new Dept
                //    {
                //        DeptName = "IT"
                //    }
                //    );
                //context.Departments.Add(
                //    new Dept
                //    {
                //        DeptName = "HR"
                //    }
                //    );
                //context.Departments.Add(
                //   new Dept
                //   {
                //       DeptName = "Accounts"
                //   }
                //   );
                //context.Departments.Add(
                //   new Dept
                //   {
                //       DeptName = "Sales"
                //   }
                //   );
                //context.SaveChanges();
                //context.Employees.Add(
                //    new Emp
                //    {
                //        EmpName="Emp1", Salary=32000, DeptId=1
                //    }
                //    );
                //context.Employees.Add(
                //    new Emp
                //    {
                //        EmpName = "Emp2",
                //        Salary = 20000,
                //        DeptId = 4
                //    }
                //    );
                //context.Employees.Add(
                //    new Emp
                //    {
                //        EmpName = "Emp3",
                //        Salary = 40000,
                //        DeptId = 2
                //    }
                //    );
                //context.Employees.Add(
                //    new Emp
                //    {
                //        EmpName = "Emp4",
                //        Salary = 35000,
                //        DeptId = 3
                //    }
                //    );
                //context.SaveChanges();

                var result1 = context.Departments.Include(e=>e.Employees);
                foreach(var dept in result1)
                {
                    Console.WriteLine($"{dept.DeptId} {dept.DeptName} ");
                    foreach (var e in dept.Employees)
                    {
                        Console.WriteLine($"\t{e.EmpId} {e.EmpName}");
                    }
                }
            }
        }
    }
}
