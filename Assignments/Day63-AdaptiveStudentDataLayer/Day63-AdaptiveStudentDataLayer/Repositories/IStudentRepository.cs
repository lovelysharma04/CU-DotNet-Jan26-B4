using Day63_AdaptiveStudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day63_AdaptiveStudentDataLayer.Repositories
{
    internal interface IStudentRepository
    {
        void AddStudent(Models.Student student);
        void UpdateStudent(Models.Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> GetAllStudents();
    }
}
