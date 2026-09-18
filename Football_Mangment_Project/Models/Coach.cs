using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    internal class Coach : Person 
    {
        
        public Coach(string name, int id) : base(name, id)
        {
        }
        public Coach() : base("", 0) { }
        
        public Team team { get; set; }
    }
}
