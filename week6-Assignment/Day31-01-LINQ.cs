using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace Week6Started
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
        public override string ToString()
        {
            return $"{Id} {Name} {Class} {Marks}";
        }
    }
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }
    class Product 
    { 
        public int Id; 
        public string Name; 
        public string Category; 
        public double Price; 
    }
    class Sale 
    { 
        public int ProductId; 
        public int Qty; 
    }
    class Book 
    { 
        public string Title; 
        public string Author; 
        public string Genre; 
        public int Year; 
        public double Price; 
    }

    internal class Day31_01_LINQ
    {
        static void Main(string[] args)
        {
            //================================== Student Performance Analytics =====================================
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };
            //•	Get top 3 students by marks
            var top3student = students.OrderByDescending(s => s.Marks)
                                      .Take(3);
            foreach (var stu in top3student)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------"); ;

            //•	Group students by Class and calculate average marks
            var avgByClass = students.GroupBy(s => s.Class)
                                     .Select(g => new { Class = g.Key, Avg = g.Average(s => s.Marks) });
            foreach (var avg  in avgByClass)
            {
                Console.WriteLine($"{avg.Class} - {avg.Avg}");
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------"); ;

            //•	List students who scored below class average
            var belowAvg = students.GroupBy(s => s.Class)
                                     .Select(g => new
                                     {
                                         Class = g.Key,
                                         Avg = g.Average(s => s.Marks),
                                         MarksBelowAvg = g.Where(s => s.Marks < g.Average(s => s.Marks))
                                     });
            foreach (var stu in belowAvg)
            {
                Console.WriteLine($"{stu.Class}");
                foreach (var marks in stu.MarksBelowAvg)
                {
                    Console.WriteLine($"{marks.Name} - {marks.Marks}");
                }
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------"); ;

            //•	Order students by Class then by Marks descending
            var orderStudents = students.OrderBy(s => s.Class)
                                        .ThenByDescending(m=>m.Marks);
            foreach (var stu in orderStudents)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------"); ;

            //================================  Employee Salary Processing System ==================================
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            //•	Get highest and lowest salary in each department
            var highestAndLowestSalary = employees.GroupBy(s => s.Dept)
                                                  .Select(s => new
                                                   {
                                                       Department = s.Key,
                                                       LowSalary = s.Min(l => l.Salary),
                                                       HighSalary = s.Max(h => h.Salary)
                                                   }
                                                   );
            foreach (var sal in highestAndLowestSalary)
            {
                Console.WriteLine(sal);
                
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------"); ;

            //•	Count employees per department
            var NoOfEmpPerDept = employees.GroupBy(s => s.Dept)
                                          .Select(e => new { Department = e.Key, Count = e.Count() });
            foreach (var n in NoOfEmpPerDept)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------");

            //•	Filter employees joined after 2020
            var empJoinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            foreach (var emp in empJoinedAfter2020)
            {
                Console.WriteLine($"Id: {emp.Id} | Name: {emp.Name} | Department: {emp.Dept} | Salary: {emp.Salary} | Joining Date: {emp.JoinDate:yyyy/MM/dd}");
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------");

            //•	Project anonymous objects with Name and AnnualSalary
            var obj = employees.Select(s => (s.Name, s.Salary));
            foreach (var i in obj)
            {
                Console.WriteLine($"Name: {i.Name}    Annaul Salary: {i.Salary}");
            }
            Console.WriteLine("\n------------------------------------------------------------------------------------");

            //================================ Product Inventory and Sales Query ==================================
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            //•	Join Products with Sales
            var joinedData = products.Join(sales, o => o.Id, i => i.ProductId,
                (p,s) => new {p.Name,s.Qty}
                );
            foreach (var j in joinedData)
            {
                Console.WriteLine($"{j.Name} - {j.Qty}");
            }

            //•	Calculate total revenue per product

            //•	Get best-selling product

            //•	List products with zero sales

            //================================ Library Book Management System ==================================

            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };
            //•	Find books published after 2015
            //•	Group by Genre and count books
            //•	Get most expensive book per Genre
            //•	Return distinct authors list




        }
    }
}
