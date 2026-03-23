using Day63_AdaptiveStudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day63_AdaptiveStudentDataLayer.Repositories
{
    internal class ListStudentRepository: IStudentRepository
    {
        private static List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
                students.Remove(student);
        }

        public List<Student> GetAllStudents()
        {
           return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public void UpdateStudent(Student student)
        {
            var existing = GetStudentById(student.StudentId);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
            }
        }
    }
}
