namespace Week3DotNet
{
    class Employee            //static member are class members  ||  other are instance members
    {
        static int incr;
        public static string Company { get; set; }
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }

        static Employee()
        {
            incr = 1110;
            Company = "CAPGEMINI";
            Console.WriteLine("STATIC CONSTRUCTOR");
        }

        public Employee()
        {
            incr++;
            Id = incr;
        }

        public static void ChangeName(string cname)
        {
            Company = cname;
        }

        public override string ToString()
        {
            return $"Id: {Id}  Name: {EmployeeName}  Dept: {DepartmentName} Company: {Company}";
        }
        public override bool Equals(object? obj)
        {
            Employee e2 = obj as Employee;  //(Employee)obj;
            return (this.EmployeeName.Equals(e2.EmployeeName));
            //return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
       
    }
    internal class StaticMembersDemo
    {
        static void Main(string[] args)
        {
            Employee.Company = "Capgemini";
            Employee.ChangeName("EPAM");
            Employee e1 = new Employee()
            {
                //Id = 1111,
                EmployeeName ="Emp1",
                DepartmentName ="IT"
            };
            Employee e2 = new Employee()
            {
                //Id = 1112,
                EmployeeName="Emp2",
                DepartmentName="HR"
            };
            Console.WriteLine(e1.Equals(e2));
            Console.WriteLine(e1);
            // By default type name
            Console.WriteLine(e2);
        }
    }
}
