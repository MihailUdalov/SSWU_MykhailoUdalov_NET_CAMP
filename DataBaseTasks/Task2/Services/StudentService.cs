using Task2.Models;

namespace Task2.Services
{
    internal class StudentService
    {
        public static void Add(Student student)
        {
            using (var context = new AppDbContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
        public static Student GetByID(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Students.FirstOrDefault(s => s.ID == id);
            }
        }
        public static List<Student> Get()
        {
            using (var context = new AppDbContext())
            {
                return context.Students.ToList();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var student = context.Students.FirstOrDefault(s => s.ID == id);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public static void Update(Student student)
        {
            using (var context = new AppDbContext())
            {
                var newStudent = context.Students.FirstOrDefault(s => s.ID == student.ID);
                newStudent = student;
                context.SaveChanges();
            }
        }
    }
}
