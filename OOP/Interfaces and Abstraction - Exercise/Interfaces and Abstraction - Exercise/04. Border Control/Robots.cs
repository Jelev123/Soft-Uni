namespace _04._Border_Control
{
    public class Robots : IId

    {
        private string model;

        public Robots(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}