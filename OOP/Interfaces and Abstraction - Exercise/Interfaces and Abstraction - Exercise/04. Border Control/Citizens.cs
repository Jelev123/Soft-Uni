namespace _04._Border_Control
{
    public class Citizens : IId
    {
        private string name;
        private int age;

        public Citizens(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}