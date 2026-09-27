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

        }

        static void RemoveCourse()
        {

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

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("[1] Add Student");
                Console.WriteLine("[2] View All Students");
                Console.WriteLine("[3] View Student");
                Console.WriteLine("[4] Remove Student");

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
            }
        }
    }
}