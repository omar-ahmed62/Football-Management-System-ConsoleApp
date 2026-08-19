using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    public enum TeamType
    {
        NationalTeam,
        Club
    }
    internal class Team
    {
        public TeamType TeamType { get; set; }
        public List<Player> PlayerList {  get; private set; }  // Aggregation (Team has Players)
        public Country Country { get; set; } // Association
        public Coach Coach { get; set; }  // Association
        public string TeamName { get; set; }

        public event Action<Player,Team> PlayerAdded;
        public event Action<Player, Team> PlayerRemoved;

        public Team(string TeamName,Country country, TeamType type, Coach coach)
        {
            this.TeamName= TeamName;
            this.Country= country;
            this.TeamType= type;
            this.Coach= coach;

            this.PlayerList = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if(player == null)
                throw new ArgumentNullException("NULL Exception");

            foreach (Player p in PlayerList)
            {
                if (p.ID == player.ID)
                    throw new InvalidOperationException("Player already exists in this team");

                if (p.ShirtNumber == player.ShirtNumber)
                    throw new InvalidOperationException("Shirt Number already exists");
            }

            this.PlayerList.Add(player);

            PlayerAdded?.Invoke(player, this); //Event check null exception

        }

        public void RemovePlayer(Player player)
        {
            PlayerList.Remove(player);

            PlayerRemoved?.Invoke(player, this);
        }

       

        public List<Player> SearchPlayer(Predicate<Player> filter)  
        {
            List<Player> Result = new List<Player>();
            foreach (Player item in PlayerList)
            {
                if (filter(item))
                    Result.Add(item);
            }
            return Result;
        }


        public override string ToString()
        {
            return this.TeamName;
            
        }
    }
}
