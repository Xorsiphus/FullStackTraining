using System;
using FirstApp.Mocks;
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
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //
        //     // modelBuilder.Entity<Course>().ToTable("Course");
        //     // modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //     // modelBuilder.Entity<Student>().ToTable("Student");
        //     //
        //     // base.OnModelCreating(modelBuilder);
        //     
        // }
    }
}