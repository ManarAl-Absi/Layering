using System.Collections.Generic;
using Layering.Data.Entities;

namespace Layering.Logic
{
    public interface IStudentLogic
    {
        List<Student> GetStudents();

        Student GetStudent(int id);

        void CreateStudent(string name);

        void AddStudentToCourse(int studentId, int courseId);

        void RemoveStudentFromCourse(int studentId, int courseId);
    }
}
