using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    public enum Position
    {
        GK,CB,LB,RB,CM,CDM,CAM,LW,RW,ST
    }
    internal class Player : Person
    {
        public int ShirtNumber {  get; set; }
        public Position Position { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public Player(string name, int ID, int shirtNumber, Position position) : base(name, ID)
        {
            this.Position = position;

            if (shirtNumber > 0 && shirtNumber < 100)
                this.ShirtNumber = shirtNumber;
            else
                throw new ArgumentException("Invalid ShirtNumber");
        }


        public override string ToString()
        {
            return $"{base.ToString()}\n ShirtNumber = {ShirtNumber} \n Position = {Position} \n ===================";
        }

    }
}
