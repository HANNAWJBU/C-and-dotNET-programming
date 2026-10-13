using System;
using System.Collections.Generic;

namespace FinalProject
{
    internal class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();


        // =========================================
        // STUDENT MANAGEMENT
        // =========================================

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

            Student newStudent =
                new Student(ID, Name, Major, Year);

            students.Add(newStudent);

            Console.WriteLine("Student added successfully.");
        }


        static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students have been added.");
                return;
            }

            foreach (Student student in students)
            {
                student.DisplayStudent();
                Console.WriteLine();
            }
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


        static void RemoveStudent()
        {
            Console.Write("Enter the student's ID: ");
            string studentID = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.ID == studentID)
                {
                    students.Remove(student);

                    Console.WriteLine(
                        "Student removed successfully.");

                    return;
                }
            }

            Console.WriteLine("Student not found.");
        }


        static void EditStudent()
        {
            Console.Write("Enter the student's ID: ");
            string studentID = Console.ReadLine();

            Student selectedStudent = null;

            foreach (Student student in students)
            {
                if (student.ID == studentID)
                {
                    selectedStudent = student;
                    break;
                }
            }

            if (selectedStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            selectedStudent.DisplayStudent();

            Console.WriteLine();

            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Major");
            Console.WriteLine("[3] Year");

            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Enter the new name: ");

                selectedStudent.Name = Console.ReadLine();

                Console.WriteLine(
                    "Name updated successfully.");
            }
            else if (option == "2")
            {
                Console.Write("Enter the new major: ");

                selectedStudent.Major = Console.ReadLine();

                Console.WriteLine(
                    "Major updated successfully.");
            }
            else if (option == "3")
            {
                Console.Write("Enter the new year: ");

                selectedStudent.Year = Console.ReadLine();

                Console.WriteLine(
                    "Year updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }


        // =========================================
        // COURSE MANAGEMENT
        // =========================================

        static void AddCourse()
        {
            Console.Write("Enter the course ID: ");
            string courseID = Console.ReadLine();

            Console.Write("Enter the course name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter the instructor's name: ");
            string instructor = Console.ReadLine();

            Course newCourse =
                new Course(
                    courseID,
                    courseName,
                    instructor);

            courses.Add(newCourse);

            Console.WriteLine(
                "Course added successfully.");
        }


        static void ViewAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine(
                    "No courses have been added.");

                return;
            }

            foreach (Course course in courses)
            {
                course.DisplayCourse();
                Console.WriteLine();
            }
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


        static void RemoveCourse()
        {
            Console.Write("Enter the course ID: ");
            string courseID = Console.ReadLine();

            foreach (Course course in courses)
            {
                if (course.CourseID == courseID)
                {
                    courses.Remove(course);

                    // Remove the course from students
                    // who are enrolled in it.
                    foreach (Student student in students)
                    {
                        student.RemoveCourse(courseID);
                    }

                    Console.WriteLine(
                        "Course removed successfully.");

                    return;
                }
            }

            Console.WriteLine("Course not found.");
        }


        // =========================================
        // ENROLLMENT
        // =========================================

        static void AddCourseToStudent()
        {
            Console.Write("Enter the student's ID: ");
            string studentID = Console.ReadLine();

            Student selectedStudent = null;

            foreach (Student student in students)
            {
                if (student.ID == studentID)
                {
                    selectedStudent = student;
                    break;
                }
            }

            if (selectedStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }


            Console.Write("Enter the course ID: ");
            string courseID = Console.ReadLine();

            Course selectedCourse = null;

            foreach (Course course in courses)
            {
                if (course.CourseID == courseID)
                {
                    selectedCourse = course;
                    break;
                }
            }

            if (selectedCourse == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }


            // Check whether the student is already enrolled.
            foreach (Course course in selectedStudent.Courses)
            {
                if (course.CourseID == courseID)
                {
                    Console.WriteLine(
                        "Student is already enrolled " +
                        "in this course.");

                    return;
                }
            }


            selectedStudent.AddCourse(selectedCourse);

            Console.WriteLine(
                "Course added to student successfully.");
        }


        static void RemoveCourseFromStudent()
        {
            Console.Write("Enter the student's ID: ");
            string studentID = Console.ReadLine();

            Student selectedStudent = null;

            foreach (Student student in students)
            {
                if (student.ID == studentID)
                {
                    selectedStudent = student;
                    break;
                }
            }

            if (selectedStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }


            Console.Write("Enter the course ID: ");
            string courseID = Console.ReadLine();

            bool enrolled = false;

            foreach (Course course in selectedStudent.Courses)
            {
                if (course.CourseID == courseID)
                {
                    enrolled = true;
                    break;
                }
            }


            if (!enrolled)
            {
                Console.WriteLine(
                    "Student is not enrolled in that course.");

                return;
            }


            selectedStudent.RemoveCourse(courseID);

            Console.WriteLine(
                "Course removed from student successfully.");
        }


        // =========================================
        // GRADES
        // =========================================

        static void AddGrade()
        {

        }


        static void RemoveGrade()
        {

        }


        // =========================================
        // OOP DEMONSTRATION
        // =========================================

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


        // =========================================
        // MAIN MENU
        // =========================================

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();

                Console.WriteLine(
                    "===== Online Learning Management System =====");

                Console.WriteLine("[1] Add Student");
                Console.WriteLine("[2] View All Students");
                Console.WriteLine("[3] View Student");
                Console.WriteLine("[4] Remove Student");
                Console.WriteLine("[5] Edit Student");

                Console.WriteLine("[6] Add Course");
                Console.WriteLine("[7] View All Courses");
                Console.WriteLine("[8] View Course");
                Console.WriteLine("[9] Remove Course");

                Console.WriteLine("[10] Add Course to Student");
                Console.WriteLine("[11] Remove Course from Student");

                Console.WriteLine(
                    "[12] Demonstrate User Dashboard");

                Console.WriteLine("[0] Exit");

                Console.Write("Choose an option: ");

                string Choice = Console.ReadLine();

                Console.WriteLine();


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
                    Console.Write(
                        "Enter the student's ID: ");

                    string studentID =
                        Console.ReadLine();

                    ViewStudent(studentID);
                }

                else if (Choice == "4")
                {
                    RemoveStudent();
                }

                else if (Choice == "5")
                {
                    EditStudent();
                }

                else if (Choice == "6")
                {
                    AddCourse();
                }

                else if (Choice == "7")
                {
                    ViewAllCourses();
                }

                else if (Choice == "8")
                {
                    Console.Write(
                        "Enter the course ID: ");

                    string courseID =
                        Console.ReadLine();

                    ViewCourse(courseID);
                }

                else if (Choice == "9")
                {
                    RemoveCourse();
                }

                else if (Choice == "10")
                {
                    AddCourseToStudent();
                }

                else if (Choice == "11")
                {
                    RemoveCourseFromStudent();
                }

                else if (Choice == "12")
                {
                    DemonstrateUserDashboards();
                }

                else if (Choice == "0")
                {
                    Console.WriteLine(
                        "Exiting program.");

                    break;
                }

                else
                {
                    Console.WriteLine(
                        "Invalid option.");
                }
            }
        }
    }
}