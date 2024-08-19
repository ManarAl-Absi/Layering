using System.Collections.Generic;
using System.Linq;
using Layering.Data.Entities;
using Layering.Repository;

namespace Layering.Logic
{
    public class CourseLogic : ICourseLogic
    {
        private readonly ICourseRepository _courseRepository;

        public CourseLogic(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CreateCourse(string name)
        {
            Course course = new Course
            {
                Name = name
            };

            _courseRepository.Add(course);
        }

        public List<Course> GetCourses()
        {
            return _courseRepository.GetAll().ToList();
        }
    }
}
