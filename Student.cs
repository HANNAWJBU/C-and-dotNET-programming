using System.Collections.Generic;

namespace FinalProject
{
    internal class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public string Year { get; set; }

        public Student(string id, string name, string major, string year)
        {
            ID = id;
            Name = name;
            Major = major;
            Year = year;
        }

        public List<Course> Courses { get; set; } = [];

        public void AddCourseToStudent(Course course)
        {
            Courses.Add(course);
        }
        public void DisplayStudent()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Major: {Major}");
            Console.WriteLine($"Year: {Year}");

        }
    }
}