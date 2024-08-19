using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Layering.Data.Entities;
using Layering.Repository;

namespace Layering.Logic
{
    public class StudentLogic : IStudentLogic
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentLogic(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            Student student = _studentRepository.GetOne(studentId);

            if (student == null)
            {
                throw new Exception("Student does not exist");
            }

            Course course = _courseRepository.GetOne(courseId);

            if (course == null)
            {
                throw new Exception("Course does not exist");
            }

            student.CourseId = course.Id;

            _studentRepository.Update(student);
        }

        public void CreateStudent(string name)
        {
            Student student = new Student { Name = name };
            _studentRepository.Add(student);
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.GetOne(id);
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetAll().ToList();
        }

        public void RemoveStudentFromCourse(int studentId, int courseId)
        {
            Student student = _studentRepository.GetOne(studentId);

            if (student == null)
            {
                throw new Exception("Student does not exist");
            }

            Course course = _courseRepository.GetOne(courseId);

            if (course == null)
            {
                throw new Exception("Course does not exist");
            }

            student.CourseId = null;

            _studentRepository.Update(student);
        }
    }
}
