namespace _03._Players_and_Monsters
{
    public class Hero
    {
        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username { get; set; }
        public int Level { get; set; }

        #region Overrides of Object

      
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

        #endregion
    }
}