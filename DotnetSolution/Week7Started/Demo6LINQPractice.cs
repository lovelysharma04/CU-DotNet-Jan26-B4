using System.Xml.Serialization;

namespace Week7Started
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }
        public string City { get; set; }
    }

    class Course
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
    }
    class Order
    {
        public int OrderId { get; set; }
        public List<string> Items { get; set; }
    }
    internal class Demo6LINQPractice
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var students = new List<Student>
                {
                    new Student{ Id=1, Name="Amit", Age=21, Marks=85, City="Delhi"},
                    new Student{ Id=2, Name="Riya", Age=19, Marks=92, City="Mumbai"},
                    new Student{ Id=3, Name="Karan", Age=22, Marks=75, City="Delhi"},
                    new Student{ Id=4, Name="Sneha", Age=20, Marks=88, City="Pune"},
                };

            var courses = new List<Course>
                {
                    new Course{ Id=1, StudentId=1, CourseName="C#"},
                    new Course{ Id=2, StudentId=2, CourseName="Java"},
                    new Course{ Id=3, StudentId=1, CourseName="SQL"},
                };
            Console.WriteLine("Hello, LINQ!\n");

            Console.WriteLine("---------------------------------------------------------------");
            //Display odd numbers
            var oddNum = numbers.Where(x => x % 2 != 0);
            Console.WriteLine(string.Join(", ",oddNum));

            Console.WriteLine("---------------------------------------------------------------");
            //display even numbers in decending order
            var evenNum = numbers.Where(e => e % 2 == 0).OrderByDescending(x=>x);
            Console.WriteLine(string.Join(", ", evenNum));

            Console.WriteLine("---------------------------------------------------------------");
            //show students of delhi
            var delhiStu = students.Where(x => x.City == "Delhi")
                                   .Select(x=>x.Name);
            Console.WriteLine(string.Join(", ", delhiStu));
            //foreach(var s in delhiStu)
            //{
            //    Console.WriteLine(s.Name);
            //}

            Console.WriteLine("---------------------------------------------------------------");
            //display unique city from students
            var diffCity = students.Select(c=>c.City).Distinct();
            Console.WriteLine(string.Join(", ", diffCity));

            Console.WriteLine("---------------------------------------------------------------");
            //display name and city of all students
            var NameCity = students.Select(a=>new { a.Name, a.City });
            Console.WriteLine(string.Join("\n", NameCity));

            Console.WriteLine("---------------------------------------------------------------");
            //display students having 'a' in name
            var stu = students.Where(x => x.Name.Contains("a")).Select(a=>a.Name);
            Console.WriteLine(string.Join("\n", stu));

            Console.WriteLine("---------------------------------------------------------------");
            //display student name and course name
            var CourseOfStudent = students.Join(courses, 
                s=>s.Id, c=>c.StudentId,
                (s,c)=> new {s.Name, c.CourseName}
                );
            foreach(var s in CourseOfStudent)
            {
                Console.WriteLine(s.Name +" "+  s.CourseName); 
            }

            Console.WriteLine("---------------------------------------------------------------");
            //display students no course name
            var NoCourse = students.GroupJoin(courses,
                s => s.Id, c => c.StudentId,
                (s, c) => new { s.Id, s.Name , Joined = c.Any()}
                ).Where(s=>!s.Joined);
            Console.WriteLine("ID" + " "+ "Name");
            Console.WriteLine("--------");
            foreach(var s in NoCourse)
            {
                Console.WriteLine(s.Id+"  "+s.Name);
            }
            Console.WriteLine("---------------------------------------------------------------");
            //check Students have age above 18
            var allAbove18 = students.All(s => s.Age > 18);
            Console.WriteLine(allAbove18 ? "YES" : "NO");

            //Any() 
            var anyBelow18= students.Any(s => s.Age <18);
            Console.WriteLine(anyBelow18? "YES": "NO");

            Console.WriteLine("---------------------------------------------------------------");
            //display city wise student count
            var cityCountStu = students.GroupBy(s=>s.City)
                                       .Select(s=>new {City= s.Key, count= s.Count(), TotalMarks = s.Sum(f=>f.Marks)});
            foreach(var city in cityCountStu)
            {
                Console.WriteLine(city.City+"   "+ city.count+"   "+city.TotalMarks);
            }

            Console.WriteLine("---------------------------------------------------------------");
            //SET OPERATIONS
            List<int> l1 = new List<int>() { 1,2,3,4,5,6,7};
            List<int> l2 = new List<int>() { 5, 6, 7,10,11,12,13 };

            var intersect = l1.Intersect(l2);
            Console.WriteLine(string.Join(",",intersect));

            var union = l1.Union(l2);
            Console.WriteLine(string.Join(",",union));

            var minus1 = l1.Except(l2);
            Console.WriteLine(string.Join(",", minus1));

            var chars = students.SelectMany(s => s.Name);
            Console.WriteLine(string.Join(",", chars));
            var charr = students.Select(s => s.Name);
            Console.WriteLine(string.Join(",", charr));
            Console.WriteLine("---------------------------------------------------------");
            var orders = new List<Order>
            {
                new Order{ OrderId = 1, Items = new List<string>{"Laptop","Mouse"}},
                new Order{ OrderId = 2, Items = new List<string>{"Keyboard"}}
            };
            //----------------------Select all will flatten the nested list-------------------------
            var list3 = orders.SelectMany(s => s.Items);
            Console.WriteLine(string.Join(",", list3));
            Console.WriteLine();

            var list4 = orders.Select(s => s.Items);
            foreach (var item in list4)
            {
                foreach(var i in item)
                {
                    Console.WriteLine(i);
                }
            }



        }
    }
}
