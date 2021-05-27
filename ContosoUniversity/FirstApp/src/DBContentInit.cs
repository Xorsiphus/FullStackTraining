using System;
using System.Collections.Generic;
using System.Linq;
using FirstApp.Models;

namespace FirstApp
{
    public class DBContentInit
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student{FirstMidName="Carson",LastName="Alexander",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/a/af/Apple_JE3_BE3.png",Misses = 5,EnrollmentDate=DateTime.Parse("2005-09-01")},
                    new Student{FirstMidName="Meredith",LastName="Alonso",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/5/58/Arrow_JE2_BE1.png",Misses = 2,EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Arturo",LastName="Anand",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/e/e0/Baked_Potato_JE4_BE2.png",Misses = 7,EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/1/12/Beetroot_JE2_BE2.png",Misses = 1,EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Yan",LastName="Li",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/6/6c/Beetroot_Soup_JE2_BE2.png",Misses = 111,EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Peggy",LastName="Justice",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/6/65/Black_Dye_JE1_BE1.png",Misses = 2,EnrollmentDate=DateTime.Parse("2001-09-01")},
                    new Student{FirstMidName="Laura",LastName="Norman",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/2/2e/Blue_Dye_JE1_BE1.png",Misses = 666,EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Nino",LastName="Olivetto",Avatar = "https://static.wikia.nocookie.net/minecraft_gamepedia/images/3/3a/Bone_JE3_BE2.png",Misses = 123,EnrollmentDate=DateTime.Parse("2005-09-01")}
                };
                
                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();
                var courses = new List<Course>
                {
                new Course{CourseId=1050,Title="Chemistry",Credits=3,},
                new Course{CourseId=4022,Title="Microeconomics",Credits=3,},
                new Course{CourseId=4041,Title="Macroeconomics",Credits=3,},
                new Course{CourseId=1045,Title="Calculus",Credits=4,},
                new Course{CourseId=3141,Title="Trigonometry",Credits=4,},
                new Course{CourseId=2021,Title="Composition",Credits=3,},
                new Course{CourseId=2042,Title="Literature",Credits=4,}
                };
                courses.ForEach(s => context.Courses.Add(s));
                context.SaveChanges();
                var enrollments = new List<Enrollment>
                {
                new Enrollment{StudentId=1,CourseId=1050,Grade=Grade.A},
                new Enrollment{StudentId=1,CourseId=4022,Grade=Grade.C},
                new Enrollment{StudentId=1,CourseId=4041,Grade=Grade.B},
                new Enrollment{StudentId=2,CourseId=1045,Grade=Grade.B},
                new Enrollment{StudentId=2,CourseId=3141,Grade=Grade.F},
                new Enrollment{StudentId=2,CourseId=2021,Grade=Grade.F},
                new Enrollment{StudentId=3,CourseId=1050},
                new Enrollment{StudentId=4,CourseId=1050,},
                new Enrollment{StudentId=4,CourseId=4022,Grade=Grade.F},
                new Enrollment{StudentId=5,CourseId=4041,Grade=Grade.C},
                new Enrollment{StudentId=6,CourseId=1045},
                new Enrollment{StudentId=7,CourseId=3141,Grade=Grade.A},
                };
                enrollments.ForEach(s => context.Enrollments.Add(s));
                context.SaveChanges();
            }
        }
    }
}