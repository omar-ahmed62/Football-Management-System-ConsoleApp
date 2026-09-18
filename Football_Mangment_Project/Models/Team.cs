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
        public int Id { get; set; }
        public string TeamName { get; set; }

        public TeamType TeamType { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; } 

        public int CoachId { get; set; }
        public Coach Coach { get; set; }  

        public List<Player> PlayerList { get; private set; }  


        public event Action<Player,Team> PlayerAdded;
        public event Action<Player, Team> PlayerRemoved;

        public Team() 
        {

        }

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

        public List<Player> SearchPlayer(Func<Player,bool> filter)
        {
            return PlayerList.Where(filter).ToList();
        }

        public int CountPlayersByPosition(Position position)
        {
            return PlayerList.Count(p => p.Position == position);
        }

        
        public IEnumerable<IGrouping<Position, Player>> GroupPlayersByPosition()
        {
            var result =
                from p in PlayerList
                group p by p.Position into list
                select list;

            return result;
        }

        public override string ToString()
        {
            return this.TeamName;
            
        }
    }
}
