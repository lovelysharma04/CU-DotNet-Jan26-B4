namespace EFCoreRelated.Models
{
    internal class Emp
    {
        public int EmpId {  get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public int DeptId {  get; set; }

        public Dept Department { get; set; }
    }
}
