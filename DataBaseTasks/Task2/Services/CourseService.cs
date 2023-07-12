using Task2.Models;

namespace Task2.Services
{
    internal class CourseService
    {
        public static void Add(Course course)
        {
            using (var context = new AppDbContext())
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
        public static Course GetByID(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Courses.FirstOrDefault(c => c.CourseID == id);
            }
        }
        public static List<Course> Get()
        {
            using (var context = new AppDbContext())
            {
                return context.Courses.ToList();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var course = context.Courses.FirstOrDefault(c => c.CourseID == id);
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public static void Update(Course course)
        {
            using (var context = new AppDbContext())
            {
                var newCourse = context.Courses.FirstOrDefault(c => c.CourseID == course.CourseID);
                newCourse = course;
                context.SaveChanges();
            }
        }
    }
}
