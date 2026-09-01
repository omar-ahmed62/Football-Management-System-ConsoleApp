using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Football_Mangment_Project.Models
{
    public enum TournamentType
    {
        NationalTeamsTournament,
        ClubsTournament
    }
    internal class Tournament
    {
        public string TournamentName { get; set; }
        public List<Team> TeamsParticipated { get; private set; }
        public List<Match> MatchesPlayed { get; private set; } = new List<Match>();
        public TournamentType Type { get; set; }

        public Tournament(string tournamentName, TournamentType type)
        {
            TournamentName = tournamentName;
            this.Type = type;

            this.TeamsParticipated = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            if (team == null)
                throw new ArgumentNullException("NULL Exception");

            this.TeamsParticipated.Add(team);
        }

        public void RemoveTeam(Team team) 
        {
            TeamsParticipated.Remove(team);
        }

        public void AddMatch(Match match)
        {
            if (match == null)
                throw new ArgumentNullException("Null Exception");

            MatchesPlayed.Add(match);
        }

        public List<Goal> GetAllGoals()
        {
            List<Goal> list = new List<Goal>();

            foreach (Match match in MatchesPlayed)
            {
                list.AddRange(match.AwayTeamGoals);
                list.AddRange(match.HomeTeamGoals);
                
            }
            return list;
        }

        public Player GetTopScorer()
        {
            var AllGoals= GetAllGoals();
            var grouped = AllGoals.GroupBy(s => s.Scorer);
            var result = from c in grouped
                         orderby c.Count() descending
                         select c.Key;
            
            return result.FirstOrDefault();
        }


        public override string ToString()
        {
            return $"Tournament Name = {TournamentName} \n Type = {Type}";
        }






    }
    }
