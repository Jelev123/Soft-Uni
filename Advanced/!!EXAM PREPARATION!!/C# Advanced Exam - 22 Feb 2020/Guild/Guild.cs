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
            roster = new Dictionary<string, Player>();
        }

        Dictionary<string, Player> roster = new Dictionary<string, Player>();

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => roster.Count;
        public void AddPlayer(Player player)
        {
            if (Capacity > Count && !roster.ContainsKey(player.Name))
            {
                roster.Add(player.Name,player);
                
            }
        }
        public  bool RemovePlayer(string name)
        {
            if (roster.ContainsKey(name))
            {
                roster.Remove(name);
                return true;
            }

            return false;
        }

        public  void PromotePlayer(string name)
        {
            if (roster[name].Rank != "Member")
            {
                roster[name].Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster[name].Rank != "Trial")
            {
                roster[name].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)

        {
            Player[] kicked = (new LinkedList<Player>(roster.Values.Where(x => x.Class == clas))).ToArray();
            roster = roster.Where(x => x.Value.Class != clas).ToDictionary(x => x.Key, x => x.Value);
            return kicked;
        }

     

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            if (roster.Count > 0)
            {
                foreach (var player in roster)
                {
                    sb.AppendLine(player.Value.ToString());
                }
            }
          

            return sb.ToString().TrimEnd();
        }
    }
}