
//namespace Week3DotNet
//{
//        public enum Department
//        {
//            Accounts,
//            Sales,
//            IT
//        }
//    class Employee
//    {
//        int Id;
//        public void SetId(int id)
//        {
//            Id = id;
//        }
//        public void GetId()
//        {
//            Console.WriteLine(Id);
//        }
//        public string Name { get; set; }  //string name

//        private Department department;

//        public Department Department
//        {
//            get { return department; }
//            set { department = value; }
//        }
//        private int salary;

//        public int Salary
//        {
//            get { return salary; }
//            set
//            {
//                if (value > 50000 && value < 90000)
//                    salary = value;
//            }
//        }
//    }
//        internal class Day14_Employee{
//        static void Main(string[] args)
//        {
//            Employee employee = new Employee();
//            employee.Name = "Lovely Sharma";
//            employee.SetId(1);
//            employee.GetId();
//            employee.Department = Department.Accounts;
//            employee.Salary = 70000;
//            Console.WriteLine(employee.Name);
//            Console.WriteLine(employee.Department);
//            Console.WriteLine(employee.Salary);
                   
//        }
//    }
//}
