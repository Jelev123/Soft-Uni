namespace PersonInfo
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age,string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        #region Implementation of IPerson

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get ; set ; }
        public string Birthdate { get ; set ; }

        #endregion
    }
}