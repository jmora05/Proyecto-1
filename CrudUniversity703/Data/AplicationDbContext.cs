using Microsoft.EntityFrameworkCore;
using CRUDUniversity703.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;    

namespace CRUDUniversity703.Data
{
    public class AplicationDbContext:IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
