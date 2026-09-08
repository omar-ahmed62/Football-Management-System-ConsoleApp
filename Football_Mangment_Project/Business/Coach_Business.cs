using Football_Mangment_Project.Data_Access;
using Football_Mangment_Project.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;

namespace Football_Mangment_Project.Business
{
    internal class Coach_Business
    {
        public static int AddCoach(string CoachName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CoachName",CoachName)
            };
            return DB_Layer.DML("Insert into Coach(CoachName) values (@CoachName)",parameters);
        }

        public static int GetID(string CoachName) 
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CoachName",CoachName)
            };
            DataTable dt= DB_Layer.select("select CoachID from Coach where CoachName = @CoachName ", parameters);

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["CoachID"]);

            return 0;
        }
    }
}


