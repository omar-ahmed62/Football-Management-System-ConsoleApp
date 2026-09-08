using Football_Mangment_Project.Data_Access;
using Football_Mangment_Project.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Football_Mangment_Project.Business
{
    internal class Country_Business
    {
        public static int AddCountry(string CountryName, Continent Continent)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CountryName", CountryName),
                new SqlParameter("@Continent", Continent.ToString())
            };
            
            return DB_Layer.DML("INSERT INTO Country (CountryName, Continent) VALUES (@CountryName, @Continent)",
                parameters
            );
        }


        public static int GetID(string countryName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CountryName", countryName)
            };

            DataTable dt = DB_Layer.select("SELECT CountryID FROM Country WHERE CountryName = @CountryName", parameters );

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["CountryID"]);

            return 0;
        }
    }
}
