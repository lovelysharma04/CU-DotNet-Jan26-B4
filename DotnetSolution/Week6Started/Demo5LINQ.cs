//using System.Reflection.Metadata;

//namespace Week6Started
//{
//    class Student
//    {
//        public int Id;
//        public string Name;
//        public string Class;
//        public int Marks;
//        public override string ToString()
//        {
//            return $"{Id} {Name} {Class} {Marks}";
//        }
//    }

//    class Employee
//    {
//        public int Id;
//        public string Name;
//        public string Dept;
//        public double Salary;
//        public DateTime JoinDate;
//    }

//    internal class Demo05LINQOperations
//    {
//        static void Main(string[] args)
//        {
//            var students = new List<Student>
//        {
//            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
//            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
//            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
//            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
//            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
//        };
//            //where marks >80------------
//            var moreThan80 = students.Where(s => s.Marks > 80).ToList();
//            foreach (var student in moreThan80)
//            {
//                Console.WriteLine(student);
//            }
//            //projection columns----------
//            var projection = students.Select(s => new {s.Name, s.Marks });
//            foreach (var student in projection)
//            {
//                Console.WriteLine($"{student.Name} - {student.Marks}");
//            }
//            //display total marks
//            var total = students.Sum(s => s.Marks);
//            Console.WriteLine($"Total: {total}");

//            //grouping
//            var studentClasses = students.GroupBy(s => s.Class);
//            foreach (var group in studentClasses)
//            {
//                Console.WriteLine(group.Key + " - "+ group.Count());
//                foreach (var stu in group)
//                {
//                    Console.WriteLine("\t"+ stu.Name);
//                }
//            }
//            // names contain h
//            var nameswithH = students.Where(s => s.Name.Contains("h"));

//            //top three students
//            var tops = students.OrderByDescending(o => o.Marks)
//                               .Take(3);
//            //name start with h
//            var firstnameH = students.FirstOrDefault(s => s.Name.Contains("h"));
//            Console.WriteLine(firstnameH?.Name);  //to check null use ? with object

//            //display class with avg in the class aggerate functions
//            var avgInclass = students.GroupBy(s => s.Class)
//                                     .Select(g=>
//                                     new {Class =g.Key,Avg=g.Average(s=>s.Marks)}
//                                     );
//            foreach (var avg in avgInclass)
//            {
//                Console.WriteLine(avg.Class+" - "+ avg.Avg);
//            }


//            var employees = new List<Employee>
//        {
//            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
//            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
//            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
//            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
//        };
//            //emp join after 2020
//            var empJoinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
//        }
//    }
//}
