using System.Collections.Generic;
using Layering.Data.Entities;

namespace Layering.Logic
{
    public interface ICourseLogic
    {
        List<Course> GetCourses();

        void CreateCourse(string name);
    }
}
