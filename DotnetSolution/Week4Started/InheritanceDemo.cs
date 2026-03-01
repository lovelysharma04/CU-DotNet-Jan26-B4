namespace Week4Started
{
    class Person
    {
        public Person()
        {
            AadharId = 0;
            Name = string.Empty;
        }
        public Person(int id, string name)
        {
            AadharId= id;
            Name = name;
        }
        public int AadharId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id - {AadharId}, Name - {Name}";
        }
    }
    class Student: Person
    {
        public string Degree { get; set; }
        public string CollegeName { get; set; }

        public Student() { 
            Degree = string.Empty;
            CollegeName = string.Empty;
        }
        public Student(string degree, string college)
        {
            Degree= degree;
            CollegeName= college;
        }
        public Student(int id, string name, string degree, string college):base(id,name)
        {
            Degree = degree;
            CollegeName= college;
        }
        public override string ToString() {
            return base.ToString() + $", Degree - {Degree}, College - {CollegeName}";
        }
    }
    internal class InheritanceDemo
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(111,"S1","BSc","Govind University");
            Console.WriteLine(s1);   
        }
    }
}
