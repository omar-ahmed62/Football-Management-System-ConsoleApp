using Football_Mangment_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project
{
    internal class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public DateTime MatchDate { get; set; }

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

        public void SetResult(int homeGoals, int awayGoals)
        {
            if (homeGoals < 0 || awayGoals < 0)
            {
                throw new ArgumentException("Goals cant be negative");
            }
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;

            MatchFinished?.Invoke(this);
        } 

        public string GetWinner()
        {
            if(HomeGoals >AwayGoals)
                return HomeTeam.TeamName;

            else if(AwayGoals > HomeGoals)
                return AwayTeam.TeamName;

            else return "Draw";

        }


    }
}
