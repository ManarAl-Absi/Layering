using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Layering.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int MaxStudentCount { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
