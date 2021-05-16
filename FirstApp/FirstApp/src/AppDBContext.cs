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
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder
        // .UseNpgsql("Host=localhost;Database=newDb;Username=postgres;Password=bestPassword");

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //
        //     SchoolInit.Seed(this);
        //     // modelBuilder.Entity<Student>().HasData(new Student
        //     // {
        //     //     FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01"),
        //     // });
        // }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}