namespace FinalProject
{
    internal class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }

        public Course(string courseID, string courseName, string instructor)
        {
            CourseID = courseID;
            CourseName = courseName;
            Instructor = instructor;
        }

        public void DisplayCourse()
        {
            Console.WriteLine($"Course ID: {CourseID}");
            Console.WriteLine($"Course Name: {CourseName}");
            Console.WriteLine($"Instructor: {Instructor}");
        }
    }
}