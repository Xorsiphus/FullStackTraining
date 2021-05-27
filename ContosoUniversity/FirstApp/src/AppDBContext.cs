using FirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentForExpulsion> StudentsForExpulsion { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<StudentForExpulsion>()
        //         .HasOne(s => s.Student);
        //         // .WithOne()
        //         // .HasForeignKey<StudentForExpulsion>(s => s.StudentId);
        // }
    }
}