using Layering.Data;
using Layering.Data.Entities;
using System.Linq;

namespace Layering.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityDbContext universityDbContext) : base(universityDbContext)
        {
        }

        public override Course GetOne(int id)
        {
            return UniversityDbContext
                .Courses
                .SingleOrDefault(student => student.Id == id);
        }
    }
}
