using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Person(string name,int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be more than zero");
            }

            this.ID= id;
            this.Name=name;
        }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $" ID = {ID} \n Name = {Name}";
        }
    }
}
