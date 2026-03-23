using Day63_AdaptiveStudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Day63_AdaptiveStudentDataLayer.Repositories
{
    internal class JsonStudentRepository: IStudentRepository
    {
        private static string file = @"../../../students.json";

        private List<Student> LoadData()
        {
            if (!File.Exists(file))
                return new List<Student>();

            string json = File.ReadAllText(file);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Student>();

            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        private void SaveData(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);
        }

        public void AddStudent(Student student)
        {
            var students = LoadData();
            students.Add(student);
            SaveData(students);
        }

        public void DeleteStudent(int id)
        {
            var students = LoadData();
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                students.Remove(student);
                SaveData(students);
            }
        }

        public List<Student> GetAllStudents()
        {
            return LoadData();
        }

        public Student GetStudentById(int id)
        {
            return LoadData().FirstOrDefault(s => s.StudentId == id);
        }

        public void UpdateStudent(Student student)
        {
            var students = LoadData();
            var existing = students.FirstOrDefault(s => s.StudentId == student.StudentId);

            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
                SaveData(students);
            }
        }
    }
}
