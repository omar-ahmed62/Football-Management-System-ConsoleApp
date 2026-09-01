using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    internal class Goal
    {
        public Player Scorer {  get; set; }
        public int Minute {  get; set; }

        public Goal(Player scorer, int minute)
        {
            if (scorer == null)
                throw new ArgumentNullException("Scorer cannot be null");

            if (minute < 0 || minute > 120)
                throw new ArgumentException("Invalid minute");

            this.Scorer = scorer;
            this.Minute = minute;
        }



    }
}
