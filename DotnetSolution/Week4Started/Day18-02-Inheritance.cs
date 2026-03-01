namespace Week4Started
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }
        public Employee(int empId, string empName, decimal basicSalary, int exp=0)
        {
            EmployeeId = empId;
            EmployeeName = empName;
            BasicSalary = basicSalary;
            ExperienceInYears = exp;    
        }

        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"EmployeeID: {EmployeeId}");
            Console.WriteLine($"Name: {EmployeeName}");
            Console.WriteLine($"Salary: {CalculateAnnualSalary():F2}");
            Console.WriteLine($"Experience: {ExperienceInYears}");

        }
    }
    class PermanentEmployee: Employee
    {
        public PermanentEmployee(int empId, string empName, decimal basicSalary, int exp):base(empId, empName, basicSalary, exp)
        {
            EmployeeId = empId;
            EmployeeName = empName;
            BasicSalary = basicSalary;
            ExperienceInYears = exp;
        }

        public new decimal CalculateAnnualSalary()
        {
            decimal HRA = 0.2m * BasicSalary * 12;
            decimal SpecialAllowance = 0.1m * BasicSalary * 12;
            decimal AnnualSalary = BasicSalary * 12 + HRA + SpecialAllowance;
            if (ExperienceInYears >= 5)
            {
                AnnualSalary=AnnualSalary + 50000;
            }
            return AnnualSalary;
        }
    }
    class ContractEmployee: Employee
    {
        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int empId, string empName, decimal basicSalary, int contract) : base(empId, empName, basicSalary)
        {
            EmployeeId = empId;
            EmployeeName = empName;
            BasicSalary = basicSalary;
            //ExperienceInYears = exp;
            ContractDurationInMonths = contract;
        }
        public new decimal CalculateAnnualSalary()
        {
            
            decimal AnnualSalary = BasicSalary * 12;
            if (ContractDurationInMonths >= 12)
            {
                AnnualSalary = AnnualSalary + 30000;
            }
            return AnnualSalary;
        }
    }
    class InternEmployee: Employee
    {
        public InternEmployee(int empId, string empName, decimal basicSalary) : base(empId, empName, basicSalary)
        {
            EmployeeId = empId;
            EmployeeName = empName;
            BasicSalary = basicSalary;
            
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }


    }
    internal class Day18_02_Inheritance
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(01,"Lovely",35000,2);
            PermanentEmployee e2 = new PermanentEmployee(02, "Nitin", 6500, 6);
            ContractEmployee e3 = new ContractEmployee(03, "Rohit", 34000,12);
            InternEmployee e4 = new InternEmployee(04, "Aniket", 32000);
            Console.WriteLine($"emp1: {e1.CalculateAnnualSalary()}"); // Base method
            Console.WriteLine($"emp2: {e2.CalculateAnnualSalary()}");
            Console.WriteLine($"emp2: {e3.CalculateAnnualSalary()}");
            Console.WriteLine($"emp4: {e4.CalculateAnnualSalary()}");

        }
    }
}
