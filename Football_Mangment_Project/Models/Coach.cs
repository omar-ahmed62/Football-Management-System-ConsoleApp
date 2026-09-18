using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    internal class Coach : Person 
    {
        
        public Coach(string name) : base(name)
        {
        }
        public Coach() : base("") 
        {
        }
        
        public Team team { get; set; }
    }
}
