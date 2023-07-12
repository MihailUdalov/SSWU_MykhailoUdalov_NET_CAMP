using Task2.Models;

namespace Task2.Services
{
    internal class EnrollmentService
    {
        public static void Add(Enrollment enrollment)
        {
            using (var context = new AppDbContext())
            {
                context.Enrollments.Add(enrollment);
                context.SaveChanges();
            }
        }

        public static Enrollment GetByID(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Enrollments.FirstOrDefault(c => c.EnrollmentID == id);
            }
        }

        public static List<Enrollment> Get()
        {
            using (var context = new AppDbContext())
            {
                return context.Enrollments.ToList();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var enrollment = context.Enrollments.FirstOrDefault(c => c.EnrollmentID == id);
                context.Enrollments.Remove(enrollment);
                context.SaveChanges();
            }
        }

        public static void Update(Enrollment enrollment)
        {
            using (var context = new AppDbContext())
            {
                var newCourse = context.Enrollments.FirstOrDefault(c => c.EnrollmentID == enrollment.EnrollmentID);
                newCourse = enrollment;
                context.SaveChanges();
            }
        }
    }
}
