using Layering.Data;
using Layering.Data.Entities;
using System.Linq;

namespace Layering.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityDbContext universityDbContext) : base(universityDbContext)
        {
        }

        public override Student GetOne(int id)
        {
            return UniversityDbContext
                .Students
                .SingleOrDefault(student => student.Id == id);
        }
    }
}
