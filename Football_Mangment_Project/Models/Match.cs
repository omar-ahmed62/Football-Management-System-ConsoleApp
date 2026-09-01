using Football_Mangment_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project
{
    public enum TeamGoal
    {
        Home,
        Away
    }
    internal class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public List<Goal> HomeTeamGoals { get; set; } = new List<Goal>();
        public List<Goal> AwayTeamGoals { get; set; } = new List<Goal>();

        public event Action<Match> MatchFinished;


        public Match (Team HomeTeam, Team AwayTeam)
        {
            if(HomeTeam ==AwayTeam)
            {
                throw new ArgumentException("HomeTeam = AwayTeam");
            }
            this.HomeTeam = HomeTeam;
            this.AwayTeam = AwayTeam;
        }

        public int GetHomeGoals()
        {
            return HomeTeamGoals.Count;
        }

        public int GetAwayGoals()
        {
            return AwayTeamGoals.Count;
        }

        
        public void AddGoal(Goal goal, TeamGoal team)
        {
            if (team == TeamGoal.Home)
                HomeTeamGoals.Add(goal);
            else
                AwayTeamGoals.Add(goal);
        }

        public void FinishMatch()
        {
            MatchFinished?.Invoke(this);
        }

        public string GetWinner()
        {
            int homeGoals = GetHomeGoals();
            int awayGoals = GetAwayGoals();

            if (homeGoals > awayGoals)
                return HomeTeam.TeamName;

            else if (homeGoals < awayGoals)
                return AwayTeam.TeamName;

            else return "Draw";
        }

        public string GetResult()
        {
            return ($"{HomeTeam.TeamName} {GetHomeGoals()} - {GetAwayGoals()} {AwayTeam.TeamName}");
        }




    }
}
