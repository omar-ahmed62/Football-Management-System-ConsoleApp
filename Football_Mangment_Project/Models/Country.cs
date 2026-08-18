using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Models
{
    public enum Continent
    {
        Africa, Europe, Asia, NorthAmerica, SouthAmerica, Oceania
    }
    internal class Country
    {
        public string CountryName { get; set; }
        public Continent Continent { get; set; }
        public Country(string countryName, Continent continent)
        {
            this.CountryName = countryName;
            this.Continent = continent;
        }
    }
}
