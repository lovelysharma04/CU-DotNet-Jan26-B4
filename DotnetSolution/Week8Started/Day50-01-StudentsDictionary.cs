
    class Student
    {
        public string StudId { get; set; }
        public string SName { get; set; }

        public Student(string id, string name)
        {
            StudId = id;
            SName = name;
        }

        public override bool Equals(object obj)
        {
            Student s = obj as Student;
            if (s == null) return false;
            return this.StudId == s.StudId;
        }

        public override int GetHashCode()
        {
            return StudId.GetHashCode();
        }
    }
    internal class Day50_01_StudentsDictionary
    {
        public static void Main()
        {
            Dictionary<Student, int> records = new Dictionary<Student, int>();

            AddOrUpdate(records, new Student("S1", "Rahul"), 80);
            AddOrUpdate(records, new Student("S2", "Amit"), 75);
            AddOrUpdate(records, new Student("S1", "Rahul"), 85); // improvement
            AddOrUpdate(records, new Student("S2", "Amit"), 70);  // no update

            Display(records);
        }

        static void AddOrUpdate(Dictionary<Student, int> records, Student s, int marks)
        {
            if (!records.ContainsKey(s))
            {
                records[s] = marks;
            }
            else
            {
                if (marks > records[s])
                {
                    records[s] = marks;
                }
            }
        }

        static void Display(Dictionary<Student, int> records)
        {
            foreach (var item in records)
            {
                Console.WriteLine(item.Key.StudId + " " + item.Key.SName + " " + item.Value);
            }
        }
    }

