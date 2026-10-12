using System;
using System.Collections.Generic;

namespace FinalProject
{
    internal class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();

        static void AddStudent()
        {
            Console.WriteLine("Enter the student's ID: ");
            string ID = Console.ReadLine();

            Console.WriteLine("Enter the student's name: ");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter the student's major: ");
            string Major = Console.ReadLine();

            Console.WriteLine("Enter the student's year: ");
            string Year = Console.ReadLine();

            Student newStudent = new Student(ID, Name, Major, Year);

            students.Add(newStudent);

            Console.WriteLine("Student added successfully.");
        }

        static void ViewAllStudents()
        {
            foreach (Student student in students)
            {
                student.DisplayStudent();
                Console.WriteLine();
            }
        }

        static void RemoveStudent()
        {
            Console.Write("Enter the student's ID: ");
            string studentID = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.ID == studentID)
                {
                    students.Remove(student);
                    Console.WriteLine("Student removed successfully.");
                    return;
                }
            }

            Console.WriteLine("Student not found.");
        }

        static void AddCourse()
        {
            Console.Write("Enter the course ID: ");
            string courseID = Console.ReadLine();

            Console.Write("Enter the course name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter the instructor's name: ");
            string instructor = Console.ReadLine();

            Course newCourse = new Course(courseID, courseName, instructor);

            courses.Add(newCourse);

            Console.WriteLine("Course added successfully.");
        }

        static void ViewAllCourses()
        {
            foreach (Course course in courses)
            {
                course.DisplayCourse();
                Console.WriteLine();
            }
        }

        static void RemoveCourse()
        {
            Console.Write("Enter the course ID: ");
            string courseID = Console.ReadLine();

            foreach (Course course in courses)
            {
                if (course.CourseID == courseID)
                {
                    courses.Remove(course);
                    Console.WriteLine("Course removed successfully.");
                    return;
                }
            }

            Console.WriteLine("Course not found.");
        }

        static void AddGrade()
        {

        }

        static void RemoveGrade()
        {

        }

        static void ViewStudent(string studentID)
        {
            foreach (Student student in students)
            {
                if (student.ID == studentID)
                {
                    student.DisplayStudent();
                    return;
                }
            }

            Console.WriteLine("Student not found.");
        }

        static void ViewCourse(string courseID)
        {
            foreach (Course course in courses)
            {
                if (course.CourseID == courseID)
                {
                    course.DisplayCourse();
                    return;
                }
            }

            Console.WriteLine("Course not found.");
        }

        static void DemonstrateUserDashboards()
        {
            User student = new Student(
                "S100",
                "John Smith",
                "Computer Science",
                "Junior"
            );

            User instructor = new Instructor(
                "I100",
                "Dr. Smith",
                "Computer Science"
            );

            User administrator = new Administrator(
                "A100",
                "Admin User"
            );

            student.DisplayDashboard();
            Console.WriteLine();

            instructor.DisplayDashboard();
            Console.WriteLine();

            administrator.DisplayDashboard();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("[1] Add Student");
                Console.WriteLine("[2] View All Students");
                Console.WriteLine("[3] View Student");
                Console.WriteLine("[4] Remove Student");
                Console.WriteLine("[5] Add Course");
                Console.WriteLine("[6] View All Courses");
                Console.WriteLine("[7] View Course");
                Console.WriteLine("[8] Remove Course");
                Console.WriteLine("[9] Demonstrate User Dashboard");

                string Choice = Console.ReadLine();

                if (Choice == "1")
                {
                    AddStudent();
                }
                else if (Choice == "2")
                {
                    ViewAllStudents();
                }
                else if (Choice == "3")
                {
                    Console.Write("Enter the student's ID: ");
                    string studentID = Console.ReadLine();

                    ViewStudent(studentID);
                }
                else if (Choice == "4")
                {
                    RemoveStudent();
                }
                else if (Choice == "5")
                {
                    AddCourse();
                }
                else if (Choice == "6")
                {
                    ViewAllCourses();
                }
                else if (Choice == "7")
                {
                    Console.Write("Enter the course ID: ");
                    string courseID = Console.ReadLine();

                    ViewCourse(courseID);
                }
                else if (Choice == "8")
                {
                    RemoveCourse();
                }
                else if (Choice == "9")
                {
                    DemonstrateUserDashboards();
                }
            }
        }
    }
}