using System;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            string output = $"Player {Name}: {Class}" + Environment.NewLine;
            output += $"Rank: {Rank}" + Environment.NewLine;
            output += $"Description: {Description}";
            return output.TrimEnd();
            //var sb = new StringBuilder();
            //sb.AppendLine($"Players in the guild: Player {Name}: {Class}")
            //    .AppendLine($"Rank: {Rank}")
            //    .AppendLine($"Description: {Description}");

            //return sb.ToString().TrimEnd();
        }
    }
}