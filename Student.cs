namespace FinalProject
{
    internal class Student : User
    {
        public string Major { get; set; }
        public string Year { get; set; }

        public Student(string id, string name, string major, string year)
            : base(id, name)
        {
            Major = major;
            Year = year;
        }

        public void DisplayStudent()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Major: {Major}");
            Console.WriteLine($"Year: {Year}");
        }

        public override void DisplayDashboard()
        {
            Console.WriteLine($"Student Dashboard - Welcome {Name}");
        }
    }
}