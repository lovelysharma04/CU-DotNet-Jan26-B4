using System.Xml.Serialization;

namespace Week4Started
{
    //Entity Class
    class StudentData
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"Id- {Id}  Name- {Name}  Marks- {Marks}"; 
        }
    }

    //Manager Class
    class StudentManager
    {
        Dictionary<int, StudentData> s = new Dictionary<int, StudentData>();
        public bool AddStudent(StudentData student)
        {
            if (!s.ContainsKey(student.Id))
            {
                s.Add(student.Id, student);
                return true;
            }
            
            return false;
        }
        public StudentData SearchStudent(int id)
        {
            StudentData student = null;
            bool found = s.TryGetValue(id, out student);    
            return student;
        }
        public bool UpdateStudent(int id, int marks)
        {
            StudentData foundStudent = SearchStudent(id);
            if( foundStudent!= null)
            {
                foundStudent.Marks = marks;
                return true;
            }
            return false;

        }
        public bool DeleteStudent(int id)
        {
             return s.Remove(id);
        }
        public void DisplayAllStudent()
        {
            foreach (var item in s)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
    internal class UseStudentManager
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            // manager.AddStudent(new StudentData() { Id = 111, Name = "Ram", Marks = 79 });
            // manager.AddStudent(new StudentData() { Id = 112, Name = "Ramesh", Marks = 89 });
            // StudentData find = manager.SearchStudent(111);
            // if(find == null)
            // {
            //     Console.WriteLine("Student Not Found!");
            // }
            // else
            // {
            //     Console.WriteLine(find);
            // }
            // Console.WriteLine("-----------------------------------------------------------------");
            // bool updated = manager.UpdateStudent(111, 97);
            // if (updated) {
            //     Console.WriteLine(manager.SearchStudent(111));
            // }
            // Console.WriteLine("-----------------------------------------------------------------");
            // bool deleted = manager.DeleteStudent(112);
            // if (deleted) {
            //     Console.WriteLine("Student Deleted");
            // }
            // Console.WriteLine("-----------------------------------------------------------------");

            //manager.DisplayAllStudent();
            int choice;
            Console.WriteLine("\n==================== Welcome ====================");
            do
            {
                
                Console.WriteLine("\n============ Student Management Menu ============");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Update Student Marks");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Display All Students");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Id of student: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        int marks = int.Parse(Console.ReadLine());

                        bool added = manager.AddStudent(new StudentData { Id = id, Name = name, Marks = marks });

                        Console.WriteLine(added ? "Student Added Successfully" : "Student Id Already Exists");
                        break;

                    case 2:
                        Console.Write("Enter Id to Search: ");
                        int searchId = int.Parse(Console.ReadLine());

                        StudentData searched = manager.SearchStudent(searchId);
                        if (searched == null)
                            Console.WriteLine("Student Not Found");
                        else
                            Console.WriteLine(searched);
                        break;

                    case 3:
                        Console.Write("Enter Id: ");
                        int updateId = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Marks: ");
                        int newMarks = int.Parse(Console.ReadLine());

                        bool updated = manager.UpdateStudent(updateId, newMarks);
                        Console.WriteLine(updated ? "Marks Updated" : "Student Not Found");
                        break;

                    case 4:
                        Console.Write("Enter Id to Delete: ");
                        int deleteId = int.Parse(Console.ReadLine());

                        bool deleted = manager.DeleteStudent(deleteId);
                        Console.WriteLine(deleted ? "Student Deleted" : "Student Not Found");
                        break;

                    case 5:
                        Console.WriteLine();
                        manager.DisplayAllStudent();
                        break;

                    case 0:
                        Console.WriteLine("Exiting Program...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice...");
                        break;
                }
            } while (choice != 0);
        }
    }
}
