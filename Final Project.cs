using System;

namespace FinalProject
{
    internal class Program
    {

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
        static void ViewStudent(var)
        {

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("[1] Add Student");
                string Choice = Console.ReadLine();

                if (Choice == "1")
                {
                    AddStudent();
                }
            }
        }
    }
}

