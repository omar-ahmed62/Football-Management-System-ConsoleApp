using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    internal class Goal
    {
        public Player Scorer {  get; set; }

        public Goal(Player scorer)
        {
            if (scorer == null)
                throw new ArgumentNullException("Scorer cannot be null");

            this.Scorer = scorer;
        }



    }
}
