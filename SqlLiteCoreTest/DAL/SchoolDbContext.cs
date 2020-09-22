using Microsoft.EntityFrameworkCore;
using SqlLiteCoreTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SqlLiteCoreTest.DAL
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { set; get; }
        public DbSet<Enrollment> Enrolments { set; get; }
        public DbSet<Course> Courses { set; get; }


        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Enrollment>();
            modelBuilder.Entity<Course>();

            //modelBuilder.Entity<Student>(e =>
            //{
            //    e.Property(p => p.ID).IsRequired();
            //    e.Property(p => p.FirstMidName);
            //    e.Property(p => p.LastName);
            //    e.Property(p => p.Enrollments);
            //});

            //https://www.learnentityframeworkcore.com/migrations/seeding
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    ID = 1,
                    FirstMidName = "William",
                    LastName = "Shakespeare",
                    EnrollmentDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 2, FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { ID = 3, FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { ID = 4, FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { ID = 5, FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { ID = 6, FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { ID = 7, FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { ID = 8, FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { ID = 9, FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
            );


            //this.SaveChanges();
            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
            //    new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
            //    new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
            //);


            //modelBuilder.Entity<Enrollment>(e =>
            //{
            //    e.HasOne(p => p.Student)
            //        .WithMany(w => w.Enrollments);
            //    e.HasOne(p => p.Course)
            //        .WithMany(w => w.Enrollments);
            //    e.

            //});
            //this.Database.EnsureCreated();
        }
    }
}
