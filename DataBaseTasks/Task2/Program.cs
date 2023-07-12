using Task2.Models;
using Task2.Services;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Add a course
            var course = new Course
            {
                Title = "Mathematics",
                Credits = 3
            };
            CourseService.Add(course);
            Console.WriteLine("Course added: " + course.Title);

            // Add a student
            var student = new Student
            {
                LastName = "Smith",
                FirstMidName = "John",
                EnrollmentDate = DateTime.Now
            };
            StudentService.Add(student);
            Console.WriteLine("Student added: " + student.FirstMidName + " " + student.LastName);

            // Add an enrollment
            var enrollment = new Enrollment
            {
                CourseID = course.CourseID,
                StudentID = student.ID,
                Grade = Grade.A
            };
            EnrollmentService.Add(enrollment);
            Console.WriteLine("Enrollment added");

            // Get the enrollment by ID
            var retrievedEnrollment = EnrollmentService.GetByID(enrollment.EnrollmentID);
            Console.WriteLine("Retrieved enrollment: Grade - " + retrievedEnrollment.Grade);

            // Update the enrollment
            retrievedEnrollment.Grade = Grade.B;
            EnrollmentService.Update(retrievedEnrollment);
            Console.WriteLine("Updated enrollment: Grade - " + retrievedEnrollment.Grade);

            // Delete the enrollment
            EnrollmentService.Delete(retrievedEnrollment.EnrollmentID);
            Console.WriteLine("Enrollment deleted.");

            // Delete the course
            CourseService.Delete(course.CourseID);
            Console.WriteLine("Course deleted.");

            // Delete the student
            StudentService.Delete(student.ID);
            Console.WriteLine("Student deleted.");

            Console.ReadLine();
        }
    }
}
