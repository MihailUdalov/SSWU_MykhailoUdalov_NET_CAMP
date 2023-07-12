using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2
{
    internal class AppDbContext : DbContext
    {
        readonly string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public AppDbContext()
           : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
