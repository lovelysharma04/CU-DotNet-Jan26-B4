using Day63_AdaptiveStudentDataLayer.Models;
using Day63_AdaptiveStudentDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day63_AdaptiveStudentDataLayer.Services
{
    internal class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository { get; set; }
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void AddStudent(Student student)
        {
            if(string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentException("Student name cannot be null or empty.");
            }
            if(student.Grade < 0 || student.Grade > 100)
            {
                throw new ArgumentException("Student grade must be between 0 and 100.");
            }
            _studentRepository.AddStudent(student);

        }

        public void DeleteStudent(int id)
        {
            if(_studentRepository.GetStudentById(id) == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }
            _studentRepository.DeleteStudent(id);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            if(_studentRepository.GetStudentById(id) == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }
            return _studentRepository.GetStudentById(id);
        }

        public void UpdateStudent(Student student)
        {
            if(_studentRepository.GetStudentById(student.StudentId) == null)
            {
                throw new ArgumentException($"Student with id {student.StudentId} does not exist.");
            }
            _studentRepository.UpdateStudent(student);
        }
    }
}
