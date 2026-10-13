using System;
using System.Collections.Generic;

namespace FinalProject
{
    internal class Student : User
    {
        public string Major { get; set; }
        public string Year { get; set; }

        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(string id, string name, string major, string year)
            : base(id, name)
        {
            Major = major;
            Year = year;

            Courses = new List<Course>();
            Grades = new List<Grade>();
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public void RemoveCourse(string courseID)
        {
            Courses.RemoveAll(course => course.CourseID == courseID);
        }

        public void DisplayStudent()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Major: {Major}");
            Console.WriteLine($"Year: {Year}");

            Console.WriteLine("Courses:");

            if (Courses.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Course course in Courses)
                {
                    Console.WriteLine($"{course.CourseID}: {course.CourseName}");
                }
            }
        }

        public override void DisplayDashboard()
        {
            Console.WriteLine($"Student Dashboard - Welcome {Name}");
        }
    }
}