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

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("[1] Add Student");
                Console.WriteLine("[2] View All Students");

                string Choice = Console.ReadLine();

                if (Choice == "1")
                {
                    AddStudent();
                }
                else if (Choice == "2")
                {
                    ViewAllStudents();
                }
            }
        }
    }
}

