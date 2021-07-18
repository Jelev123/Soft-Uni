namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        #region Implementation of IPerson

        public string Name { get; set; }
        public int Age { get; set; }

        #endregion
    }
}