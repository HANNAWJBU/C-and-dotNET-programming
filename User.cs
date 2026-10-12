namespace FinalProject
{
    internal abstract class User
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public User(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public abstract void DisplayDashboard();
    }
}