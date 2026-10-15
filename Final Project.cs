using System;
using System.Collections.Generic;
using System.Linq;

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

        static void EditCourse()
        {
            Console.Write("Enter the course's ID: ");
            string courseID = Console.ReadLine();
            ViewCourse(courseID);
            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Instructor");
            Console.WriteLine("[3] Back to Main Menu");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter the new name: ");
                string newName = Console.ReadLine();
                foreach (Course course in courses)
                {
                    if (course.CourseID == courseID)
                    {
                        course.CourseName = newName;
                        Console.WriteLine("Name updated successfully.");
                        break;
                    }
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the new instructor: ");
                string newInstructor = Console.ReadLine();
                foreach (Course course in courses)
                {
                    if (course.CourseID == courseID)
                    {
                        course.Instructor = newInstructor;
                        Console.WriteLine("Instructor updated successfully.");
                        break;
                    }
                }
            }
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


            // Make sure the student is actually enrolled.
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
                    "Student is not enrolled in this course.");

                return;
            }


            // Make sure a grade does not already exist.
            foreach (Grade grade in selectedStudent.Grades)
            {
                if (grade.CourseID == courseID)
                {
                    Console.WriteLine(
                        "A grade already exists for this course.");

                    return;
                }
            }


            Console.Write("Enter the grade (0-100): ");

            if (!double.TryParse(Console.ReadLine(), out double score))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            if (score < 0 || score > 100)
            {
                Console.WriteLine(
                    "Grade must be between 0 and 100.");

                return;
            }


            Grade newGrade = new Grade(courseID, score);

            selectedStudent.Grades.Add(newGrade);

            Console.WriteLine("Grade added successfully.");
        }

        static void ViewStudentGrades()
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


            if (selectedStudent.Grades.Count == 0)
            {
                Console.WriteLine(
                    "This student does not have any grades.");

                return;
            }


            Console.WriteLine();
            Console.WriteLine($"Grades for {selectedStudent.Name}:");

            foreach (Grade grade in selectedStudent.Grades)
            {
                string courseName = "Unknown Course";

                foreach (Course course in courses)
                {
                    if (course.CourseID == grade.CourseID)
                    {
                        courseName = course.CourseName;
                        break;
                    }
                }

                Console.WriteLine(
                    $"{grade.CourseID} - {courseName}: " +
                    $"{grade.Score} ({grade.GetLetterGrade()})");
            }
        }

        static void CalculateStudentAverage()
        {
            Console.Write("Enter the student's ID: ");
            string studentID = Console.ReadLine();

            Student selectedStudent = students.Find(
                student => student.ID == studentID
            );

            if (selectedStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            if (selectedStudent.Grades.Count == 0)
            {
                Console.WriteLine(
                    "This student does not have any grades.");
                return;
            }

            double average = selectedStudent.Grades
                .Average(grade => grade.Score);

            Console.WriteLine();
            Console.WriteLine($"Student: {selectedStudent.Name}");
            Console.WriteLine($"Grade Average: {average:F2}");
        }

        static void RemoveGrade()
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

            Grade selectedGrade = null;

            foreach (Grade grade in selectedStudent.Grades)
            {
                if (grade.CourseID == courseID)
                {
                    selectedGrade = grade;
                    break;
                }
            }

            if (selectedGrade == null)
            {
                Console.WriteLine(
                    "No grade was found for that course.");

                return;
            }


            selectedStudent.Grades.Remove(selectedGrade);

            Console.WriteLine("Grade removed successfully.");
        }

        // =========================================
        // WORKDAY OOP DEMONSTRATION
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
            bool studentUser = false;
            bool instructorUser = false;
            bool administratorUser = false;

            void Login()
            {
                Console.WriteLine("Please enter your username and password.");
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                if (username == "student" && password == "123")
                {
                    studentUser = true;
                    Console.WriteLine("Welcome, Student!");
                    
                }
                else if (username == "instructor" && password == "123")
                {
                    instructorUser = true;
                    Console.WriteLine("Welcome, Instructor!");
                }
                else if (username == "admin" && password == "123")
                {
                    administratorUser = true;
                    Console.WriteLine("Welcome, Administrator!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }

            Login();

            while (true)
            {
                if (studentUser == true)
                {
                    Console.WriteLine("Please enter your student ID:");
                    string studentID = Console.ReadLine();

                    Student student = students.Find(s => s.ID == studentID);

                    if (student == null)
                    {
                        Console.WriteLine("Invalid student ID.");
                        Console.WriteLine("This will work when we add files to save students outside of the program.");
                        continue;
                    } 
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("===== Online Learning Management System =====");

                        Console.WriteLine(" ");

                        Console.WriteLine("[1] View Courses");
                        Console.WriteLine("[2] Add Course");
                        Console.WriteLine("[3] Drop Course");
                        Console.WriteLine("[4] View Grades");
                        Console.WriteLine("[5] View Instructors");

                        Console.WriteLine(" ");
                        Console.WriteLine("[0] Exit");

                        Console.Write("Choose an option: ");

                        string Choice = Console.ReadLine();

                        Console.WriteLine();

                        if (Choice == "1")
                        {
                            student.ViewCourses();
                        }
                        else if (Choice == "2")
                        {
                            AddCourseToStudent();
                        }
                        else if (Choice == "3")
                        {
                            RemoveCourseFromStudent();
                        }
                        else if (Choice == "4")
                        {
                            ViewStudentGrades();
                        }
                        else if (Choice == "5")
                        {
                            foreach (Course course in student.Courses)
                            {
                                Console.WriteLine($"Instructor for {course.CourseName}: {course.Instructor}");
                            }
                        }
                        else if (Choice == "0")
                        {
                            Console.WriteLine("Exiting program.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                        }
                    }
                }    
                else if (instructorUser == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== Online Learning Management System =====");

                    Console.WriteLine(" ");
                    Console.WriteLine("[1] Add Course");
                    Console.WriteLine("[2] View All Courses");
                    Console.WriteLine("[3] View Course");
                    Console.WriteLine("[4] Remove Course");
                    Console.WriteLine("[5] Edit Course");

                    Console.WriteLine("");
                    Console.WriteLine("[6] Add Grade");
                    Console.WriteLine("[7] Remove Grade");
                    Console.WriteLine("[8] View Student Grades");
                    Console.WriteLine("[9] Calculate Student Average");

                    Console.WriteLine(" ");
                    Console.WriteLine("[0] Exit");

                    Console.Write("Choose an option: ");

                    string Choice = Console.ReadLine();

                    Console.WriteLine();

                    if (Choice == "1")
                    {
                        AddCourse();
                    }
                    else if (Choice == "2")
                    {
                        ViewAllCourses();
                    }
                    else if (Choice == "3")
                    {
                        Console.Write("Enter the course ID: ");
                        string courseID = Console.ReadLine();
                        ViewCourse(courseID);
                    }
                    else if (Choice == "4")
                    {
                        RemoveCourse();
                    }
                    else if (Choice == "5")
                    {
                        EditCourse();
                    }
                    else if (Choice == "6")
                    {
                        AddGrade();
                    }
                    else if (Choice == "7")
                    {
                        RemoveGrade();
                    }
                    else if (Choice == "8")
                    {
                        ViewStudentGrades();
                    }

                    else if (Choice == "9")
                    {
                        CalculateStudentAverage();
                    }

                    else if (Choice == "0")
                    {
                        Console.WriteLine("Exiting program.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }


                }
                else if (administratorUser == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== Online Learning Management System =====");

                    Console.WriteLine(" ");
                    Console.WriteLine("[1] Add Student");
                    Console.WriteLine("[2] View All Students");
                    Console.WriteLine("[3] View Student");
                    Console.WriteLine("[4] Remove Student");
                    Console.WriteLine("[5] Edit Student");

                    Console.WriteLine(" ");
                    Console.WriteLine("[6] Add Course");
                    Console.WriteLine("[7] View All Courses");
                    Console.WriteLine("[8] View Course");
                    Console.WriteLine("[9] Remove Course");
                    Console.WriteLine("[10] Edit Course");

                    Console.WriteLine(" ");
                    Console.WriteLine("[11] Add Course to Student");
                    Console.WriteLine("[12] Remove Course from Student");

                    Console.WriteLine(" ");
                    Console.WriteLine("[13] Demonstrate User Dashboard");
                    Console.WriteLine("[14] Add Grade");
                    Console.WriteLine("[15] View Student Grades");
                    Console.WriteLine("[16] Remove Grade");
                    Console.WriteLine("[17] Calculate Student Average");

                    Console.WriteLine(" ");
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
                        EditCourse();
                    }

                    else if (Choice == "11")
                    {
                        AddCourseToStudent();
                    }

                    else if (Choice == "12")
                    {
                        RemoveCourseFromStudent();
                    }

                    else if (Choice == "13")
                    {
                        DemonstrateUserDashboards();
                    }

                    else if (Choice == "14")
                    {
                        AddGrade();
                    }

                    else if (Choice == "15")
                    {
                        ViewStudentGrades();
                    }

                    else if (Choice == "16")
                    {
                        RemoveGrade();
                    }

                    else if (Choice == "17")
                    {
                        CalculateStudentAverage();
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
                else
                {
                    Console.WriteLine("Invalid login.");
                }  
            }
        }
    }
}