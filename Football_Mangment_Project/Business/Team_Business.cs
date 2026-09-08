using Football_Mangment_Project.Data_Access;
using Football_Mangment_Project.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Football_Mangment_Project.Business
{
    internal class Team_Business
    {
        public static int AddTeam(string TeamName, int CountryId,TeamType teamtype, int CoachId )
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@teamname", TeamName),
                new SqlParameter("@CountryId", CountryId),
                new SqlParameter("@teamtype", teamtype.ToString()),
                new SqlParameter("@CoachId", CoachId)

            };

            return DB_Layer.DML("Insert into team (TeamName, CountryId, teamtype, CoachId) values (@teamname, @CountryId, @teamtype, @CoachId) ", parameters);
             
        }

        public static DataTable GetAllTeams()
        {
            return DB_Layer.select("select * from Team");
        }

        public static int GetID(string teamName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeamName", teamName)
            };

            DataTable dt = DB_Layer.select("SELECT TeamID FROM Team WHERE TeamName = @TeamName", parameters);

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["TeamID"]);

            return 0;
        }
    }
}
