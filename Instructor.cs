namespace FinalProject
{
    internal class Instructor : User
    {
        public string Department {  get; set; }

        public Instructor(string id, string name, string department)
            : base(id, name)
        {
            Department = department;
        }

        public override void DisplayDashboard()
        {
            Console.WriteLine($"Instructor Dashboard - Welcome {Name}");
            Console.WriteLine($"Department: {Department}");
        }
    }
}