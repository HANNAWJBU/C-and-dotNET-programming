public delegate void CourseDesc(string description);

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
        
        public void FilterCourses()
        {
            List<string> Instructors = new List<string> { "Justus Selwyn", "Dr. Hepsiba", "Johnathan Newton" };
            Console.WriteLine("Enter the Instructor's name");
            string profName = Console.ReadLine();
            var filteredCourse = Instructors.Where(i => i.Contains(profName)).ToList();
        }

        public void DisplayCourse()
        {
            Console.WriteLine($"Course ID: {CourseID}");
            Console.WriteLine($"Course Name: {CourseName}");
            Console.WriteLine($"Instructor: {Instructor}");
        }

        static void WriteToConsole(string text)
        {
            Console.WriteLine($"[LOG]: {text}");
        }
        
        static void Test()
        {
            CourseDesc desc = WriteToConsole;
            desc("New Course!");
        }
    }
}