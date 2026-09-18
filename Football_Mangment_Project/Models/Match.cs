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
        public int Id { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public DateTime MatchDate { get; set; }

        public List<Goal> Goals { get; set; } = new List<Goal>();

        public event Action<Match> MatchFinished;
        
        public Match()
        {

        }

        public Match (int HomeTeamId, int AwayTeamId)
        {
            if(HomeTeamId ==AwayTeamId)
            {
                throw new ArgumentException("HomeTeam = AwayTeam");
            }
            this.HomeTeamId = HomeTeamId;
            this.AwayTeamId = AwayTeamId;
        }


        public int GetHomeGoals()
        {
            return Goals.Count(g => g.TeamGoal == TeamGoal.Home);
        }

        public int GetAwayGoals()
        {
            return Goals.Count(g => g.TeamGoal == TeamGoal.Away);
        }

        public void AddGoal(Goal goal, TeamGoal team)
        {
            goal.TeamGoal = team;
            Goals.Add(goal);
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
