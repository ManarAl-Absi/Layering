using Layering.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Layering.Data
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        // Parameterless constructor is only needed for the Code first Database update
        public UniversityDbContext()
        {
        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }


        // Only needed for Code first Database update
        // For the application the connection string will be set up in the program.cs 

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\egyetem\Layering\Layering\Layering.Data\Db.mdf;Integrated Security=True");
    }
}
