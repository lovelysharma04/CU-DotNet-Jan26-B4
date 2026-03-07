namespace EFCoreRelated.Models
{
    internal class Dept
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        //navigation
        public List<Emp> Employees { get; set; }
    }
}
