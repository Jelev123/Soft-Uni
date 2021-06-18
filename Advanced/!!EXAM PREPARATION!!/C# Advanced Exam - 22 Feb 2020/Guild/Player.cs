﻿using System.Text;

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

        #region Overrides of Object

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}")
                .AppendLine($"Rank: {Rank}")
                .AppendLine($"Description: {Description}");

            return sb.ToString().TrimEnd();
        }

        #endregion
    }
}