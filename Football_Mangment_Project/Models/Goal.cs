using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    internal class Goal
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int PlayerId { get; set; }
        public Player Scorer { get; set; }

        public TeamGoal TeamGoal { get; set; }

        public Goal() 
        {

        }

        public Goal(Player scorer)
        {
            if (scorer == null)
                throw new ArgumentNullException("Scorer cannot be null");

            this.Scorer = scorer;
        }



    }
}
