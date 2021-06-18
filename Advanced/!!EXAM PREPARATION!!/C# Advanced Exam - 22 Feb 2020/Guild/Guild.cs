using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {


        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new Dictionary<string, Player>(Capacity);
        }
        private Dictionary<string, Player> roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;
        public void AddPlayer(Player recruit)
        {
            if (Capacity > Count && !roster.ContainsKey(recruit.Name))
            {
                roster.Add(recruit.Name, recruit);
            }
        }
        public bool RemovePlayer(string name)
        {

            if (roster.ContainsKey(name))
            {
                roster.Remove(name);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            if (roster.ContainsKey(name))
            {
                if (roster[name].Rank != "Member")
                {
                    roster[name].Rank = "Member";
                }
            }

        }
        public void DemotePlayer(string name)
        {
            if (roster.ContainsKey(name))
            {
                if (roster[name].Rank != "Trial")
                {
                    roster[name].Rank = "Trial";
                }
            }

        }
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] kicked = (new List<Player>(roster.Values.Where(x => x.Class == clas))).ToArray();
            roster = roster.Where(x => x.Value.Class != clas).ToDictionary(x => x.Key, x => x.Value);
            return kicked;
        }
        public string Report()
        {
            string output = $"Players in the guild: {Name}";
            if (roster.Count > 0)
            {
                foreach (var player in roster)
                {
                    output += Environment.NewLine + player.Value.ToString() ;
                }
            }
            return output;
        }
    }
}