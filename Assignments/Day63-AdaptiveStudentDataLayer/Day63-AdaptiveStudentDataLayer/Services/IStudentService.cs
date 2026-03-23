using Day63_AdaptiveStudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day63_AdaptiveStudentDataLayer.Services
{
    internal interface IStudentService
    {
            void AddStudent(Student student);
            List<Student> GetAllStudents();
            Student GetStudentById(int id);
            void UpdateStudent(Student student);
            void DeleteStudent(int id);
    }
}
