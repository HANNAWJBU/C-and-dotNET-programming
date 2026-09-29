using System.Security.Cryptography.X509Certificates;

namespace FinalProject
{
    internal sealed class Administrator : User
    {
        public Administrator(string id, string name)
            : base(id, name)
        {
        }

        public override void DisplayDashboard()
        {
            Console.WriteLine($"Administrator Dashboard - Welcome {Name}");
        }
    }
}