namespace Week8Started
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Student(int id, string name)
        {
            Id=id;
            Name = name;
        }
        public override bool Equals(object? obj)
        {
            return obj is Student s && Id == s.Id && Name==s.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
        public override string ToString()
        {
            return $"Id = {Id}  Name = {Name}";
        }

    }
    class StudentManager
    {
        Dictionary<Student, int> record = new Dictionary<Student, int>();
        
        public void AddStudentImprovement(Student s,int m)
        {
            if (!record.ContainsKey(s))
            {
                record.Add(s,m);
            }
            else
            {
                if (m > record[s])
                {
                    record[s] = m; 
                }
            }         
        }
        public void PrintAll()
        {
            foreach (var student in record)
            {
                Console.WriteLine($"{student.Key}  Marks = {student.Value}");
            }
        }
    }   
    internal class PracticeDictionary01
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            manager.AddStudentImprovement(new Student(1, "Rohit"), 85);
            manager.AddStudentImprovement(new Student(2, "Amit"), 92);
            manager.AddStudentImprovement(new Student(3, "Nina"), 72);

            Student s1 = new Student(1, "Rohit");
            Student s2 = new Student(4, "Ron");

            manager.AddStudentImprovement(s1, 90);
            manager.AddStudentImprovement(s2, 89);

            manager.PrintAll();
        }
    }
}
