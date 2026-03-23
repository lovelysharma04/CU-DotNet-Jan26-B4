using Day63_AdaptiveStudentDataLayer.Models;
using Day63_AdaptiveStudentDataLayer.Repositories;
using Day63_AdaptiveStudentDataLayer.Services;

namespace Day63_AdaptiveStudentDataLayer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Storage:");
            Console.WriteLine("1. In-Memory");
            Console.WriteLine("2. JSON File");

            string choice = Console.ReadLine();

            IStudentRepository repo;

            if (choice == "1")
                repo = new ListStudentRepository();
            else
                repo = new JsonStudentRepository();

            IStudentService service = new StudentService(repo);

            Menu(service);
        }
        static void Menu(IStudentService service)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. View All");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddStudent(service);
                        break;

                    case "2":
                        foreach (var s in service.GetAllStudents())
                            Console.WriteLine($"{s.StudentId} - {s.Name} - {s.Grade}");
                        break;

                    case "3":
                        AddStudent(service, true);
                        break;

                    case "4":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        service.DeleteStudent(id);
                        break;

                    case "5":
                        return;
                }
            }
        }

        static void AddStudent(IStudentService service, bool isUpdate = false)
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            int grade = int.Parse(Console.ReadLine());

            var student = new Student { StudentId = id, Name = name, Grade = grade };

            if (isUpdate)
                service.UpdateStudent(student);
            else
                service.AddStudent(student);
        }

    }
}
