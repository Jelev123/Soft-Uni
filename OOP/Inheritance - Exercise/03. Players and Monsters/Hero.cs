namespace _03._Players_and_Monsters
{
    public class Hero
    {
        public Hero(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public string Name { get; set; }
        public int Level { get; set; }


        #region Overrides of Object

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Name} Level: {this.Level}";
        }

        #endregion
    }
}